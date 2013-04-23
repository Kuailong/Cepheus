using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cepheus.DataAccess;
using Cepheus.DataAccess.Entities;
using Cepheus.DataAccess.Enums;
using Cepheus.Entities;
using System.IO;

namespace Prototipo
{
    public partial class Interface1 : Form
    {
        private WebApiRequester requester = new WebApiRequester(eMediaType.Json);
        private ResourcesRepository repository;
        private string gamesUrl = "http://localhost/Cepheus/Games";
        private string gameTypesUrl = "http://localhost/Cepheus/GameTypes";
        private string developsUrl = "http://localhost/Cepheus/Developers";
        private string localFilePath = @"c:\temp";
        private Game lastChecked = new Game();

        public Interface1()
        {
            InitializeComponent();
            repository = new ResourcesRepository(requester);
            SetGetGames();
            SetAddGame();
            SetChangeGames();
        }

        private void relatórioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var intRelatorio = new InterfaceRelatorio();
            intRelatorio.ShowDialog();
            this.Show();
        }

        private void trackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form2 = new Interface2();
            this.Hide();
            form2.ShowDialog();
            this.Show();
        }
        
        #region GetGame

        private void SetGetGames()
        {
            var games = repository.GetMany<Game>(gamesUrl);
            var log = new Log();
            log.RegisterLog(games, txtLog, gamesUrl);

            if (!games.IsSuccessStatusCode)
            {
                MessageBox.Show("Não existe nenhum game cadastrado");
                return;
            }

            lstBoxSearch.Items.Clear();
            lstBoxSearch.DataSource = games.Content.ToList();
            lstBoxSearch.DisplayMember = "Name";
            lstBoxSearch.SelectedIndex = 0;

            SetGetGame(games.Content.First());
        }

        private void SetGetGame(Game game)
        {
            lblGameNameGet.Text = game.Name;
            lblGameDescGet.Text = game.Description;
            lblGameDevelopGet.Text = game.Developer.Name;
            listGetType.Items.Clear();
            listGetType.Items.AddRange(game.GameAndTypes.Select(e => e.GameType).ToArray());
            listGetType.DisplayMember = "Name";
            if (game.Image != null)
                using (var ms = new MemoryStream(game.Image))
                {
                    imgGame.Image = Image.FromStream(ms);
                    imgGame.Visible = true;
                }
            else
                imgGame.Visible = false;
        }

        private void gameId_SelectedIndexChanged(object sender, EventArgs e)
        {
            var itemSelected = (Game)lstBoxSearch.SelectedValue;
            if (itemSelected.GameId == lastChecked.GameId)
                return;
            var url = string.Format("{0}/{1}", gamesUrl, itemSelected.GameId);
            var result = repository.Get<Game>(url);
            SetGetGame(result.Content);
            var log = new Log();
            log.RegisterLog(result, txtLog, url);
            lastChecked = result.Content;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var text = txtSearch.Text;
            var url = string.Format("{0}/Search/{1}", gamesUrl, text);
            var result = repository.GetMany<Game>(url);
            if (!result.IsSuccessStatusCode)
            {
                if (!string.IsNullOrEmpty(text))
                    MessageBox.Show("Não foram encontrados jogos com essa busca: " + text);
                result = repository.GetMany<Game>(gamesUrl);
            }

            var log = new Log();
            log.RegisterLog(result, txtLog, url);

            if (!result.IsSuccessStatusCode)
                return;

            lstBoxSearch.DataSource = result.Content.ToList();
            lstBoxSearch.DisplayMember = "Name";
            lstBoxSearch.SelectedIndex = 0;

            SetGetGame(result.Content.First());
        }

        #endregion

        #region CreateGame

        private void SetAddGame()
        {
            var types = repository.GetMany<GameType>(gameTypesUrl);
            lstBoxTypes.DataSource = types.Content.ToList();
            lstBoxTypes.Refresh();
            lstBoxTypes.DisplayMember = "Name";
            lstBoxTypes.SelectedIndex = 0;

            var develops = repository.GetMany<Developer>(developsUrl);
            cbxDesenv.DataSource = develops.Content.ToList();
            cbxDesenv.Refresh();
            cbxDesenv.DisplayMember = "Name";
            cbxDesenv.SelectedIndex = 0;

            txtImage.Text = string.Empty;
            txtAddGameName.Text = string.Empty;
            txtAddGameDescrip.Text = string.Empty;

            lstBoxTypeAdded.DataSource = null;
            lstBoxTypeAdded.Refresh();
        }

        private void btnAddDevelop_Click(object sender, EventArgs e)
        {
            var addDesenv = new AddDesenvolvedora();
            addDesenv.ShowDialog();
            var desenv = new Developer() { Name = addDesenv.NameDesenv, Description = addDesenv.DescriptDesenv };
            var ds = (List<Developer>)cbxDesenv.DataSource;
            ds.Add(desenv);
            cbxDesenv.DataSource = ds.ToList();
            cbxDesenv.Refresh();
            cbxDesenv.SelectedItem = ds.Where(f => f == desenv).FirstOrDefault();
        }

        private void btnAddGameType_Click(object sender, EventArgs e)
        {
            var addType = new AddType();
            addType.ShowDialog();
            var type = new GameType() { Name = addType.NameType, Description = addType.NameType };
            var ds = (List<GameType>)lstBoxTypeAdded.DataSource;
            ds.Add(type);
            lstBoxTypeAdded.DataSource = ds.ToList();
            lstBoxTypeAdded.Refresh();
        }

        private void btnAddType_Click(object sender, EventArgs e)
        {
            if (lstBoxTypes.Items == null || lstBoxTypes.Items.Count == 0)
                return;

            var item = (GameType)lstBoxTypes.SelectedValue;
            var dataSource = (List<GameType>)lstBoxTypes.DataSource;
            var addDataSource = lstBoxTypeAdded.DataSource != null ? (List<GameType>)lstBoxTypeAdded.DataSource : new List<GameType>();
            addDataSource.Add(item);
            dataSource.Remove(item);
            lstBoxTypeAdded.DataSource = addDataSource.ToList();
            lstBoxTypeAdded.DisplayMember = "Name";
            lstBoxTypes.DataSource = dataSource.ToList();
            lstBoxTypeAdded.Refresh();
            lstBoxTypes.Refresh();
        }

        private void btnRemoveType_Click(object sender, EventArgs e)
        {
            if (lstBoxTypeAdded.DataSource == null || lstBoxTypeAdded.Items.Count == 0)
                return;

            var item = (GameType)lstBoxTypeAdded.SelectedValue;
            var dataSource = (List<GameType>)lstBoxTypes.DataSource;
            var addDataSource = lstBoxTypeAdded.DataSource != null ? (List<GameType>)lstBoxTypeAdded.DataSource : new List<GameType>();
            dataSource.Add(item);
            addDataSource.Remove(item);
            lstBoxTypeAdded.DataSource = addDataSource.ToList();
            lstBoxTypeAdded.DisplayMember = "Name";
            lstBoxTypes.DataSource = dataSource.ToList();
            lstBoxTypeAdded.Refresh();
            lstBoxTypes.Refresh();
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();

            if (fileDialog.ShowDialog() == DialogResult.OK)
                txtImage.Text = fileDialog.FileName;
        }

        private void btnAddGame_Click(object sender, EventArgs e)
        {
            var name = txtAddGameName.Text;
            var descrip = txtAddGameDescrip.Text;
            var develop = (Developer)cbxDesenv.SelectedValue;

            byte[] image = null;
            if (!string.IsNullOrEmpty(txtImage.Text))
                try
                {
                    image = File.ReadAllBytes(txtImage.Text);
                }
                catch
                {
                }

            var developId = develop.DeveloperId;
            var game = new Game()
            {
                Name = name,
                Description = descrip,
                Image = image,
                GameAndTypes = new List<GameAndType>(),
                Developer = developId == 0 ? develop : null,
                DeveloperId = developId
            };

            foreach (var item in lstBoxTypeAdded.Items)
            {
                var type = (GameType)item;
                game.GameAndTypes.Add(new GameAndType() { GameType = type });
            }

            var result = repository.Post<Game>(gamesUrl, game);
            if (result.IsSuccessStatusCode)
                MessageBox.Show("Jogo adicionado.");
            else
                MessageBox.Show("Não foi possível adicionar o jogo.");

            SetAddGame();
        }

        #endregion

        #region ChangeGame

        private void SetChangeGames()
        {
            var games = repository.GetMany<Game>(gamesUrl);
            var log = new Log();
            log.RegisterLog(games, txtLog, gamesUrl);

            if (!games.IsSuccessStatusCode)
            {
                MessageBox.Show("Não existe nenhum game cadastrado");
                return;
            }

            listGames2.Items.Clear();
            listGames2.DataSource = games.Content.ToList();
            listGames2.DisplayMember = "Name";
            listGames2.SelectedIndex = 0;

            SetChangeGame(games.Content.First());
        }

        private void SetChangeGame(Game game)
        {
            txtGameName.Text = game.Name;
            txtGameDescrip.Text = game.Description;

            var develops = repository.GetMany<Developer>(developsUrl);
            cbxDevelop.DataSource = develops.Content.ToList();
            cbxDevelop.Refresh();
            cbxDevelop.DisplayMember = "Name";
            cbxDevelop.SelectedItem = develops.Content.Where(e => e.DeveloperId == game.DeveloperId).First();

            listAddType.Items.Clear();
            listAddType.Items.AddRange(game.GameAndTypes.Select(e => e.GameType).ToArray());
            listAddType.DisplayMember = "Name";

            var types = repository.GetMany<GameType>(gameTypesUrl);
            listType.DataSource = types.Content.ToList();
            listType.Refresh();
            listType.DisplayMember = "Name";
            listType.SelectedIndex = 0;

            txtImageAlt.Text = string.Empty;
        }

        private void btnAddDevelop_Click_Change(object sender, EventArgs e)
        {
            var addDesenv = new AddDesenvolvedora();
            addDesenv.ShowDialog();
            var desenv = new Developer() { Name = addDesenv.NameDesenv, Description = addDesenv.DescriptDesenv };
            var ds = (List<Developer>)cbxDevelop.DataSource;
            ds.Add(desenv);
            cbxDevelop.DataSource = ds.ToList();
            cbxDevelop.Refresh();
            cbxDevelop.SelectedItem = ds.Where(f => f == desenv).FirstOrDefault();
        }

        private void btnCreateType_Click(object sender, EventArgs e)
        {
            var addType = new AddType();
            addType.ShowDialog();
            var type = new GameType() { Name = addType.NameType, Description = addType.NameType };
            var ds = (List<GameType>)listAddType.DataSource;
            ds.Add(type);
            listAddType.DataSource = ds.ToList();
            listAddType.Refresh();
        }

        private void btnAddType2_Click(object sender, EventArgs e)
        {
            if (listType.Items == null || listType.Items.Count == 0)
                return;

            var item = (GameType)listType.SelectedValue;
            var dataSource = (List<GameType>)listType.DataSource;
            var addDataSource = listAddType.DataSource != null ? (List<GameType>)listAddType.DataSource : new List<GameType>();
            addDataSource.Add(item);
            dataSource.Remove(item);
            listAddType.DataSource = addDataSource.ToList();
            listAddType.DisplayMember = "Name";
            listType.DataSource = dataSource.ToList();
            listAddType.Refresh();
            listType.Refresh();
        }

        private void btnRemoveType2_Click(object sender, EventArgs e)
        {
            if (listAddType.DataSource == null || listAddType.Items.Count == 0)
                return;

            var item = (GameType)listAddType.SelectedValue;
            var dataSource = (List<GameType>)listType.DataSource;
            var addDataSource = listAddType.DataSource != null ? (List<GameType>)listAddType.DataSource : new List<GameType>();
            dataSource.Add(item);
            addDataSource.Remove(item);
            listAddType.DataSource = addDataSource.ToList();
            listAddType.DisplayMember = "Name";
            listType.DataSource = dataSource.ToList();
            listAddType.Refresh();
            listType.Refresh();
        }

        private void btnSearch2_Click(object sender, EventArgs e)
        {
            var text = txtSearch2.Text;
            var url = string.Format("{0}/Search/{1}", gamesUrl, text);
            var result = repository.GetMany<Game>(url);
            if (!result.IsSuccessStatusCode)
            {
                if (!string.IsNullOrEmpty(text))
                    MessageBox.Show("Não foram encontrados jogos com essa busca: " + text);
                result = repository.GetMany<Game>(gamesUrl);
            }

            var log = new Log();
            log.RegisterLog(result, txtLog, url);

            if (!result.IsSuccessStatusCode)
                return;

            listGames2.DataSource = result.Content.ToList();
            listGames2.DisplayMember = "Name";
            listGames2.SelectedIndex = 0;

            SetChangeGame(result.Content.First());
        }

        private void changeGameId_SelectedIndexChanged(object sender, EventArgs e)
        {
            var itemSelected = (Game)listGames2.SelectedValue;
            if (itemSelected.GameId == lastChecked.GameId)
                return;
            var url = string.Format("{0}/{1}", gamesUrl, itemSelected.GameId);
            var result = repository.Get<Game>(url);
            SetChangeGame(result.Content);
            var log = new Log();
            log.RegisterLog(result, txtLog, url);
            lastChecked = result.Content;
        }

        private void btnNewImage_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();

            if (fileDialog.ShowDialog() == DialogResult.OK)
                txtImageAlt.Text = fileDialog.FileName;
        }

        private void btnSaveChange_Click(object sender, EventArgs e)
        {
            var itemSelected = (Game)listGames2.SelectedValue;
            var name = txtGameName.Text;
            var descrip = txtGameDescrip.Text;
            var develop = (Developer)cbxDevelop.SelectedValue;

            byte[] image = null;
            if (!string.IsNullOrEmpty(txtImageAlt.Text))
                try
                {
                    image = File.ReadAllBytes(txtImageAlt.Text);
                }
                catch
                {
                }

            var developId = develop.DeveloperId;
            var game = new Game()
            {
                GameId = itemSelected.GameId,
                Name = name,
                Description = descrip,
                Image = image,
                GameAndTypes = new List<GameAndType>(),
                Developer = developId == 0 ? develop : null,
                DeveloperId = developId
            };

            foreach (var item in listAddType.Items)
            {
                var type = (GameType)item;
                game.GameAndTypes.Add(new GameAndType() { GameType = type });
            }

            var endpoint = string.Format("{0}/{1}", gamesUrl, itemSelected.GameId);
            var result = repository.Put<Game>(endpoint, game);
            if (result.IsSuccessStatusCode)
                MessageBox.Show("Jogo adicionado.");
            else
                MessageBox.Show("Não foi possível adicionar o jogo.");

            SetChangeGames();
        }

        #endregion
    }

    public class ComboBoxItem
    {
        public string Text { get; set; }
        public string Value { get; set; }

        public ComboBoxItem(string text, string value)
        {
            Text = text;
            Value = value;
        }

        public override string ToString()
        {
            return Text;
        }
    }

    public class Log
    {
        public void RegisterLog<T>(ResourceResult<T> result, TextBox txtBox, string url)
        {
            var text = txtBox.Text;
            text =
                "--------------------------" + Environment.NewLine +
                "Url: " + url +
                "Status: " + result.StatusCode.ToString() + Environment.NewLine +
                "Response Content:" + result.ResponseMessage.Content.ReadAsStringAsync().Result + Environment.NewLine +
                "--------------------------" + Environment.NewLine + Environment.NewLine + text;

            txtBox.Text = text;
        }

        internal void RegisterLog<T>(ResourceResult<IEnumerable<T>> result, TextBox txtBox, string url)
        {
            var text = txtBox.Text;
            text =
                "--------------------------" + Environment.NewLine +
                "Url: " + url +
                "Status: " + result.StatusCode.ToString() + Environment.NewLine +
                "Response Content:" + result.ResponseMessage.Content.ReadAsStringAsync().Result + Environment.NewLine +
                "--------------------------" + Environment.NewLine + Environment.NewLine + text;

            txtBox.Text = text;
        }
    }
}
