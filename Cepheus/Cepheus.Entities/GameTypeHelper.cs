using Cepheus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cepheus.Infrastructure
{
    public class GameTypeHelper
    {
        #region Private Properties

        private IEnumerable<GameType> _currentData;

        #endregion

        #region Constructor

        public GameTypeHelper(Repository<GameType> repository)
        {
            this._currentData = repository.Get();
        }

        #endregion

        #region Public Methods

        public void FixDuplicationDatas(ICollection<GameAndType> items)
        {

            foreach (var item in items)
                this.FixDuplicationData(item);
        }

        public void FixDuplicationData(GameAndType item)
        {
            if (item.GameType != null && this.HasLogDataType(item.GameType))
            {
                item.GameTypeId = this._currentData
                    .Where(c => c.Description == item.GameType.Description)
                    .First()
                    .GameTypeId;

                item.GameType = null;
            }
        }

        public void FixInvalidData(Game game)
        {
            var invalidLogDatas = new List<GameAndType>();

            foreach (var item in game.GameAndTypes)
            {
                if (!IsValidData(item))
                    invalidLogDatas.Add(item);

                if (item.GameTypeId != 0 &&
                    item.GameType != null &&
                    item.GameType.Description != this._currentData.FirstOrDefault(c => c.GameTypeId == item.GameTypeId).Description)
                    item.GameType = null;
            }

            invalidLogDatas.ForEach(i => game.GameAndTypes.Remove(i));
        }

        public bool IsValidData(GameAndType item)
        {
            if (item.GameTypeId != 0)
                return true;

            if (item.GameTypeId == 0 && item.GameType != null && this.IsValidDataType(item.GameType))
                return true;

            return false;
        }

        public bool HasLogDataType(GameType item)
        {
            return this._currentData
                .Select(e => e.Description)
                .Contains(item.Description);
        }

        public bool IsValidDataType(GameType item)
        {
            return !string.IsNullOrEmpty(item.Description) && !string.IsNullOrWhiteSpace(item.Description);
        }

        #endregion
    }
}