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

        public Interface1()
        {
            InitializeComponent();
            repository = new ResourcesRepository(requester);
            SetGetGames();
            SetAddGame();
        }

        private void SetAddGame()
        {
            var types = repository.GetMany<Types>(gameTypesUrl);
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
            listGetType.Items.AddRange(game.GameTypes.Select(e => e.GameType).ToArray());
            listGetType.DisplayMember = "Name";
            if (game.Image != null)
                using (var ms = new MemoryStream(game.Image))
                {
                    pictureBox1.Image = Image.FromStream(ms);
                }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            var addDesenv = new AddDesenvolvedora();
            addDesenv.ShowDialog();
            var desenvName = new Developer() { Name = addDesenv.NameDesenv, Description = addDesenv.DescriptDesenv };
            cbxDesenv.Items.Add(desenvName);
            cbxDesenv.SelectedText = desenvName.Name;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            var addType = new AddType();
            addType.ShowDialog();
            var nameType = addType.NameType;
            lstBoxTypeAdded.Items.Add(nameType);
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

        private void gameId_SelectedIndexChanged(object sender, EventArgs e)
        {
            var itemSelected = (Game)lstBoxSearch.SelectedValue;
            var url = string.Format("{0}/{1}", gamesUrl, itemSelected.GameId);
            var result = repository.Get<Game>(url);
            SetGetGame(result.Content);
            var log = new Log();
            log.RegisterLog(result, txtLog, url);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var text = txtSearch.Text;
            var url = string.Format("{0}/Search/{1}", gamesUrl, text);
            var result = repository.GetMany<Game>(url);
            if (!result.IsSuccessStatusCode)
            {
                MessageBox.Show("Não foram encontrados jogos com essa busca: {0}", text);
                result = repository.GetMany<Game>(gamesUrl);
                return;
            }

            var log = new Log();
            log.RegisterLog(result, txtLog, url);

            if (!result.IsSuccessStatusCode)
                throw new Exception("Games not found");

            lstBoxSearch.DataSource = result.Content.ToList();
            lstBoxSearch.DisplayMember = "Name";
            lstBoxSearch.SelectedIndex = 0;

            SetGetGame(result.Content.First());
        }

        private void btnAddType_Click(object sender, EventArgs e)
        {
            if (lstBoxTypes.Items == null || lstBoxTypes.Items.Count == 0)
                return;

            var item = (Types)lstBoxTypes.SelectedValue;
            var dataSource = (List<Types>)lstBoxTypes.DataSource;
            var addDataSource = lstBoxTypeAdded.DataSource != null ? (List<Types>)lstBoxTypeAdded.DataSource : new List<Types>();
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

            var item = (Types)lstBoxTypeAdded.SelectedValue;
            var dataSource = (List<Types>)lstBoxTypes.DataSource;
            var addDataSource = lstBoxTypeAdded.DataSource != null ? (List<Types>)lstBoxTypeAdded.DataSource : new List<Types>();
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

        }

        private void btnAddGame_Click(object sender, EventArgs e)
        {
            var name = txtAddGameName.Text;
            var descrip = txtAddGameDescrip.Text;
            var develop = (Developer)cbxDesenv.SelectedValue;

            byte[] image = null;
            if(!string.IsNullOrEmpty(txtImage.Text))
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
                GameTypes = new List<GameTypes>(),
                Developer = developId == 0 ? develop : null,
                DeveloperId = developId
            };

            foreach (var item in lstBoxTypeAdded.Items)
            {
                var type = (Types)item;
                game.GameTypes.Add(new GameTypes() { GameType = type });
            }

            var result = repository.Post<Game>(gamesUrl, game);
            if(result.IsSuccessStatusCode)
                MessageBox.Show("Jogo adicionado.");
            else
                MessageBox.Show("Não foi possível adicionar o jogo.");

            SetAddGame();
        }
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
