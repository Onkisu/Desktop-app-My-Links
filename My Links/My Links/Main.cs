using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Links
{
    public partial class Main : Form
    {
        function fn = new function();
        string query;
        public Main()
        {
            InitializeComponent();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            MyLinks.Icon = Icon;
            //notifyIcon1.ShowBalloonTip(2000);
            
        }
        void loadAction()
        {
            query = "select * from actionn";
            DataSet ds = fn.getData(query);
            tbl_Action.DataSource = ds.Tables[0];
        }
        void loadHarem()
        {
            query = "select * from harem";
            DataSet ds = fn.getData(query);
            tbl_harem.DataSource = ds.Tables[0];
        }
        void loadSci()
        {
            query = "select * from sci";
            DataSet ds = fn.getData(query);
            tbl_sci.DataSource = ds.Tables[0];
        }
        void loadIsekai()
        {
            query = "select * from isekai";
            DataSet ds = fn.getData(query);
            tbl_isekai.DataSource = ds.Tables[0];
        }
        void loadDorama()
        {
            query = "select * from dorama";
            DataSet ds = fn.getData(query);
            tbl_dorama.DataSource = ds.Tables[0];
        }
        private void Main_Load(object sender,EventArgs e)
        {
            loadAction();
            loadDorama();
            loadHarem();
            loadIsekai();
            loadSci();
        }
        void cleartext()
        {
            txtTitle.Clear();
            txtSeason.Clear();
            txtLink.Clear();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text != "" && txtSeason.Text != "" && txtLink.Text != "")
            {
                switch (label3.Text)
                {
                    case "Genre : Action":
                        query = "insert into actionn (Title,Season,Link)values('" + txtTitle.Text + "','" + txtSeason.Text + "','" + txtLink.Text + "')";
                        fn.setData(query, "Added!");
                        Main_Load(this, null);
                        cleartext();
                        break;
                    case "Genre : Harem":
                        query = "insert into harem(Title,Season,Link)values('" + txtTitle.Text + "','" + txtSeason.Text + "','" + txtLink.Text + "')";
                        fn.setData(query, "Added!");
                        Main_Load(this, null);
                        cleartext();
                        break;
                    case "Genre : Sci-Fi":
                        query = "insert into sci(Title,Season,Link)values('" + txtTitle.Text + "','" + txtSeason.Text + "','" + txtLink.Text + "')";
                        fn.setData(query, "Added!");
                        Main_Load(this, null);
                        cleartext();
                        break;
                    case "Genre : Isekai":
                        query = "insert into isekai(Title,Season,Link)values('" + txtTitle.Text + "','" + txtSeason.Text + "','" + txtLink.Text + "')";
                        fn.setData(query, "Added!");
                        Main_Load(this, null);
                        cleartext();
                        break;
                    case "Dorama":
                        if (txtGenre.Text != "")
                        {
                            query = "insert into dorama(Title,Season,Genre,Link)values('" + txtTitle.Text + "','" + txtSeason.Text + "','" + txtGenre.Text + "','"+txtLink.Text+"')";
                            fn.setData(query, "Added!");
                            Main_Load(this, null);
                            cleartext();
                        }
                        else
                        {
                            MessageBox.Show("All field are required!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;
                    default:
                        MessageBox.Show("An Error Occured!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;

                }
            }
            else
            {
                MessageBox.Show("All field are required!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            /*pictureBox2=dorama
              pictureBox3=sci
              pictureBox1=isekai
             */
            cleartext();
            loadHarem();
            label3.Text = "Genre : Harem";

            txtGenre.Visible = false;
            comboBox1.Visible = false;

            tbl_Action.Visible = false;
            tbl_dorama.Visible = false;
            tbl_harem.Visible = true;
            tbl_isekai.Visible = false;
            tbl_sci.Visible = false;

            pic_harem.Visible = true;
            pic_action.Visible = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            loadSci();
            cleartext();
            label3.Text = "Genre : Sci-Fi";

            txtGenre.Visible = false;
            comboBox1.Visible = false;

            tbl_Action.Visible = false;
            tbl_dorama.Visible = false;
            tbl_harem.Visible = false;
            tbl_isekai.Visible = false;
            tbl_sci.Visible = true;

            pic_harem.Visible = false;
            pic_action.Visible = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            loadIsekai();
            cleartext();
            label3.Text = "Genre : Isekai";

            txtGenre.Visible = false;
            comboBox1.Visible = false;

            tbl_Action.Visible = false;
            tbl_dorama.Visible = false;
            tbl_harem.Visible = false;
            tbl_isekai.Visible = true;
            tbl_sci.Visible = false;

            pic_harem.Visible = false;
            pic_action.Visible = false;
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            loadDorama();
            cleartext();
            label3.Text = "Dorama";

            txtGenre.Visible = true;
            comboBox1.Visible = true;

            tbl_Action.Visible = false;
            tbl_dorama.Visible = true;
            tbl_harem.Visible = false;
            tbl_isekai.Visible = false;
            tbl_sci.Visible = false;

            pic_harem.Visible = false;
            pic_action.Visible = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = true;
            pictureBox3.Visible = false;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            loadAction();
            cleartext();
            label3.Text = "Genre : Action";
            //tabel
            txtGenre.Visible = false;
            comboBox1.Visible = false;

            tbl_Action.Visible = true;
            tbl_dorama.Visible = false;
            tbl_harem.Visible = false;
            tbl_isekai.Visible = false;
            tbl_sci.Visible = false;
            //panel
            pic_harem.Visible = false;
            pic_action.Visible = true;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text != "" && txtSeason.Text != "" && txtLink.Text != "")
            {
                switch (label3.Text)
                {
                    case "Genre : Action":
                        query = "update actionn set Title='" + txtTitle.Text + "',Season='" + txtSeason.Text + "',Link='" + txtLink.Text + "' where id='" + txtid.Text + "'";
                        fn.setData(query, "Updated!");
                        Main_Load(this, null);
                        cleartext();
                        break;
                    case "Genre : Harem":
                        query = "update harem set Title='" + txtTitle.Text + "',Season='" + txtSeason.Text + "',Link='" + txtLink.Text + "'where id='" + txtid.Text + "'";
                        fn.setData(query, "Updated!");
                        Main_Load(this, null);
                        cleartext();
                        break;
                    case "Genre : Sci-Fi":
                        query = "update sci set Title='" + txtTitle.Text + "',Season='" + txtSeason.Text + "',Link='" + txtLink.Text + "'where id='" + txtid.Text + "'";
                        fn.setData(query, "Updated!");
                        Main_Load(this, null);
                        cleartext();
                        break;
                    case "Genre : Isekai":
                        query = "update isekai set Title='" + txtTitle.Text + "',Season='" + txtSeason.Text + "',Link='" + txtLink.Text + "'where id='" + txtid.Text + "'";
                        fn.setData(query, "Updated!");
                        Main_Load(this, null);
                        cleartext();
                        break;
                    case "Dorama":
                        if (txtGenre.Text!="")
                        {
                            query = "update dorama set Title='" + txtTitle.Text + "',Season='" + txtSeason.Text + "',Link='" + txtLink.Text + "',Genre='" + txtGenre.Text + "'where id='" + txtid.Text + "'";
                            fn.setData(query, "Updated!");
                            Main_Load(this, null);
                            cleartext();
                        }
                        else
                        {
                            MessageBox.Show("All field are required!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;
                    default:
                        MessageBox.Show("An Error Occured!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
            }
            else
            {
                MessageBox.Show("All field are required!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "")
            {
                switch (label3.Text)
                {
                    case "Genre : Action":
                        query = "delete from actionn where id='" + txtid.Text + "'";
                        fn.setData(query, "Deleted!");
                        Main_Load(this, null);
                        cleartext();
                        break;
                    case "Genre : Harem":
                        query = "delete from harem where id='" + txtid.Text + "'";
                        fn.setData(query, "Deleted!");
                        Main_Load(this, null);
                        cleartext();
                        break;
                    case "Genre : Sci-Fi":
                        query = "delete from sci where id='" + txtid.Text + "'";
                        fn.setData(query, "Deleted!");
                        Main_Load(this, null);
                        cleartext();
                        break;
                    case "Genre : Isekai":
                        query = "delete from isekai where id='" + txtid.Text + "'";
                        fn.setData(query, "Deleted!");
                        Main_Load(this, null);
                        cleartext();
                        break;
                    case "Dorama":
                        query = "delete from dorama where id='" + txtid.Text + "'";
                        fn.setData(query, "Deleted!");
                        Main_Load(this, null);
                        cleartext();
                        break;
                    default:
                        MessageBox.Show("An Error Occured!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
            }
            else
            {
                
                MessageBox.Show("No one was selected!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
       
      
      
      
     

        private void guna2TextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void panel_tab_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void tbl_Action_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tbl_Action.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                txtid.Text = tbl_Action.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTitle.Text = tbl_Action.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtSeason.Text = tbl_Action.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtLink.Text = tbl_Action.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
            else
            {
                MessageBox.Show("An Error Occured!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbl_dorama_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tbl_dorama.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                txtid.Text = tbl_dorama.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTitle.Text = tbl_dorama.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtSeason.Text = tbl_dorama.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtLink.Text = tbl_dorama.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtGenre.SelectedItem = tbl_dorama.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
            else
            {
                MessageBox.Show("An Error Occured!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbl_isekai_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tbl_isekai.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                txtid.Text = tbl_isekai.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTitle.Text = tbl_isekai.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtSeason.Text = tbl_isekai.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtLink.Text = tbl_isekai.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
            else
            {
                MessageBox.Show("An Error Occured!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbl_sci_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tbl_sci.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                txtid.Text = tbl_sci.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTitle.Text = tbl_sci.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtSeason.Text = tbl_sci.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtLink.Text = tbl_sci.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
            else
            {
                MessageBox.Show("An Error Occured!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbl_harem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tbl_harem.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                txtid.Text = tbl_harem.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTitle.Text = tbl_harem.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtSeason.Text = tbl_harem.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtLink.Text = tbl_harem.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
            else
            {
                MessageBox.Show("An Error Occured!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (txtLink.Text != "")
            {
                System.Diagnostics.Process.Start(txtLink.Text);
            }
            else
            {
                MessageBox.Show("Nothing Links!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (txtLink.Text!="") {
                Clipboard.SetText(txtLink.Text);
            }
            else
            {
                MessageBox.Show("Nothing Links!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            if (txtSc.Text != "")
            {
                switch (label3.Text)
                {
                    case "Genre : Action":
                        query = "select * from action where Title like'%"+txtSc.Text+"%'";
                        DataSet ds = fn.getData(query);
                        tbl_Action.DataSource = ds.Tables[0];
                        cleartext();
                        break;
                    case "Genre : Harem":
                        query = "select * from harem where Title like'%" + txtSc.Text + "%'";
                        DataSet dd = fn.getData(query);
                        tbl_Action.DataSource = dd.Tables[0];
                        cleartext();
                        break;
                    case "Genre : Sci-Fi":
                        query = "select * from sci where Title like'%" + txtSc.Text + "%'";
                        DataSet dr = fn.getData(query);
                        tbl_Action.DataSource = dr.Tables[0];
                        cleartext();
                        break;
                    case "Genre : Isekai":
                        query = "select * from isekai where Title like'%" + txtSc.Text + "%'";
                        DataSet da = fn.getData(query);
                        tbl_Action.DataSource = da.Tables[0];
                        cleartext();
                        break;
                    case "Dorama":
                        query = "select * from dorama where Title like'%" + txtSc.Text + "%'";
                        DataSet dg = fn.getData(query);
                        tbl_Action.DataSource = dg.Tables[0];
                        cleartext();
                        break;
                    default:
                        MessageBox.Show("An error occured!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
            }
            else
            {
                MessageBox.Show("Input Title!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
                
            }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            new about().Show();
        }

       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    loadDorama();
                }
                else
                {
                    query = "select * from dorama where Genre like'%" + comboBox1.Text + "%'";
                    DataSet ds = fn.getData(query);
                    tbl_dorama.DataSource = ds.Tables[0];
                }
            }
            else
            {
                MessageBox.Show("Select Genre!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            new contact().Show();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }
    }
}
