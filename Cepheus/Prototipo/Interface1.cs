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

namespace Prototipo
{
    public partial class Interface1 : Form
    {
        private WebApiRequester requester = new WebApiRequester(eMediaType.Json);
        private ResourcesRepository repository;
        private string gamesUrl = "http://localhost:62861/api/Games";
        private string gameTypesUrl = "http://localhost:62861/api/GameTypes";
        private string developsUrl = "http://localhost:62861/api/Developers";
        private string localFilePath = @"c:\temp";

        public Interface1()
        {
            InitializeComponent();
            repository = new ResourcesRepository(requester);

            var games = repository.GetMany<Game>(gamesUrl);
            var log = new Log();
            log.RegisterLog(games, txtLog);

            if (!games.IsSuccessStatusCode)
                throw new Exception("Games not found");
            
            cbxGameId.DataSource = games.Content.ToList();
            cbxGameId.DisplayMember = "Name";
            cbxGameId.SelectedIndex = 0;

            SetGetGame(games.Content.First());
        }

        private void SetGetGame(Game game)
        {
            lblGameNameGet.Text = game.Name;
            lblGameDescGet.Text = game.Description;
            lblGameDevelopGet.Text = game.Developer.Name;
            listGetType.Items.AddRange(game.GameTypes.ToArray());
            listGetType.DisplayMember = "Name";
            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadFile(gamesUrl + "/" + game.GameId + "/Image", localFilePath + @"\image.jpg");
            }
            pictureBox1.Image = Image.FromFile(@"c:\temp\image.jpg");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            var addDesenv = new AddDesenvolvedora();
            addDesenv.ShowDialog();
            var desenvName = new ComboBoxItem(addDesenv.NameDesenv, addDesenv.NameDesenv);
            cbxDesenv.Items.Add(desenvName);
            cbxDesenv.SelectedText = desenvName.Text;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            var addType = new AddType();
            addType.ShowDialog();
            var nameType = addType.NameType;
            listBox1.Items.Add(nameType);
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

        private void cbxGameId_SelectedIndexChanged(object sender, EventArgs e)
        {
            var itemSelected = (Game)cbxGameId.SelectedValue;
            var result = repository.Get<Game>(string.Format("{0}/{1}", gamesUrl, itemSelected.GameId));
            SetGetGame(result.Content);
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
        public void RegisterLog<T>(ResourceResult<T> result, TextBox txtBox)
        {
            txtBox.Text +=
                "--------------------------\n" +
                "Status: " + result.StatusCode.ToString() +
                "\nResponse Content:" + result.ResponseMessage.Content.ToString() +
                "--------------------------\n\n";
        }

        internal void RegisterLog<T>(ResourceResult<IEnumerable<T>> result, TextBox txtBox)
        {
            txtBox.Text +=
                "--------------------------\n" +
                "Status: " + result.StatusCode.ToString() +
                "\nResponse Content:" + result.ResponseMessage.Content.ToString() +
                "--------------------------\n\n";
        }
    }
}
