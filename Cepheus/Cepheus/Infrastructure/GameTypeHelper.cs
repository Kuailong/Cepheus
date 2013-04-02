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

        private IEnumerable<Types> _currentLogDataTypes;

        #endregion

        #region Constructor

        public GameTypeHelper(Repository<Types> repository)
        {
            this._currentLogDataTypes = repository.Get();
        }

        #endregion

        #region Public Methods

        public void FixDuplicationLogDataTypes(ICollection<GameTypes> logdatas)
        {

            foreach (var item in logdatas)
                this.FixDuplicationLogDataType(item);
        }

        public void FixDuplicationLogDataType(GameTypes item)
        {
            if (item.GameType != null && this.HasLogDataType(item.GameType))
            {
                item.GameTypeId = this._currentLogDataTypes
                    .Where(c => c.Description == item.GameType.Description)
                    .First()
                    .TypeId;

                item.GameType = null;
            }
        }

        public void FixInvalidLogDatas(Game log)
        {
            var invalidLogDatas = new List<GameTypes>();

            foreach (var item in log.GameTypes)
            {
                if (!IsValidLogData(item))
                    invalidLogDatas.Add(item);

                if (item.GameTypeId != 0 &&
                    item.GameType != null &&
                    item.GameType.Description != this._currentLogDataTypes.FirstOrDefault(c => c.TypeId == item.TypeId).Description)
                    item.GameType = null;
            }

            invalidLogDatas.ForEach(i => log.GameTypes.Remove(i));
        }

        public bool IsValidLogData(GameTypes item)
        {
            if (item.GameTypeId != 0)
                return true;

            if (item.GameTypeId == 0 && item.GameType != null && this.IsValidLogDataType(item.GameType))
                return true;

            return false;
        }

        public bool HasLogDataType(Types item)
        {
            return this._currentLogDataTypes
                .Select(e => e.Description)
                .Contains(item.Description);
        }

        public bool IsValidLogDataType(Types item)
        {
            return !string.IsNullOrEmpty(item.Description) && !string.IsNullOrWhiteSpace(item.Description);
        }

        #endregion
    }
}