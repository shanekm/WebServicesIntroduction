namespace ProteinTrackerClient
{
    using System;
    using System.ServiceModel;
    using System.Windows.Forms;
    using ProteinTrackerClient.ProteinTrackerService;

    public partial class Form1 : Form
    {
        #region Fields

        private ProteinTrackerServiceSoapClient service = new ProteinTrackerServiceSoapClient();

        private User[] users;

        #endregion

        #region Constructors and Destructors

        public Form1()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Methods

        private void Form1_Load(object sender, EventArgs e)
        {
            // SOAP Header
            var auth = new AuthenticationHeader { UserName = "Bob", Password = "Pass" };

            this.users = this.service.ListUsers(auth);
            selectUser.DataSource = users;
            selectUser.DisplayMember = "Name";
            selectUser.ValueMember = "UserId";
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            // SOAP Header
            var auth = new AuthenticationHeader { UserName = "Bob", Password = "Pass" };

            this.service.AddUser(txtName.Text, int.Parse(txtGoal.Text));
            users = service.ListUsers(auth);
            selectUser.DataSource = users;
        }

        private void selectUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = selectUser.SelectedIndex;
            txtTotalResult.Text = users[index].Total.ToString();
            txtGoalResult.Text = users[index].Goal.ToString();
        }

        // ASYNCH - non UI blocking call
        async private void button1_Click(object sender, EventArgs e)
        {
            var userId = users[selectUser.SelectedIndex].UserId;

            try
            {
                var newTotal = await service.AddProteinAsync(int.Parse(txtProtein.Text), selectUser.SelectedIndex);
                // wait until await completes then continue to next line
                users[selectUser.SelectedIndex].Total = newTotal;
            }
                // SOAP falut exception
            catch (FaultException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

    }
}