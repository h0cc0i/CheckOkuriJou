using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoCheckAndSendReport
{
    public partial class FrmMain : Form
    {

        #region Define Global Variable
        DataTable _dtbJuchuu;
        DataTable _dtbSeihinFuka;
        DataTable _dtbBuhinFuka;
        #endregion

        public FrmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void 受注残をひらくToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                #region 2016/10/28 HonC Open file 受注残リスト 

                OpenFileDialog _of = new OpenFileDialog();
                _of.Filter = "All Files (*.*)|*.*";
                _of.FilterIndex = 1;
                _of.Multiselect = false;

                if (_of.ShowDialog() == DialogResult.OK)
                {
                    _dtbJuchuu = Common.GetDataTable(_of.FileName);
                    dtgJuchuu.DataSource = _dtbJuchuu;
                }
                tabControl1.SelectedTab = tbpJuchu;
                lblMessage.Text = "出来ました。";
                lblMessage.ForeColor = Color.Blue;
                #endregion

                //2016/10/21 HonC
                //if form is not default -> do nothing
                if (_dtbJuchuu.Columns[0].ColumnName == "F1")
                {
                    //2016/10/19 
                    #region Delete 6 first row
                    int _flagcout = 0;

                    do
                    {
                        _dtbJuchuu.Rows[_flagcout].Delete();
                        _flagcout++;
                    } while (_flagcout < 7);
                    _dtbJuchuu.AcceptChanges();
                    dtgJuchuu.DataSource = _dtbJuchuu;
                    _flagcout = 0;              //reset count variable
                    #endregion

                    //2016/10/20
                    // Delete column if first row is null -> else change to value of first row
                    #region Change Column Name
                    for (int i = _dtbJuchuu.Columns.Count - 1; i >= 0; i--)
                    {
                        if (_dtbJuchuu.Rows[0][i].ToString() == "")
                        {
                            _dtbJuchuu.Columns.RemoveAt(i);
                        }
                        else
                            _dtbJuchuu.Columns[i].ColumnName = _dtbJuchuu.Rows[0][i].ToString();
                    }
                    _dtbJuchuu.AcceptChanges();
                    #endregion

                    //2016/10/20
                    //Delete row if row value is null
                    #region Delete Null Row
                    foreach (DataRow _row in _dtbJuchuu.Select())
                    {
                        if (string.IsNullOrEmpty(_row["予 定"].ToString()))
                        {
                            _row.Delete();
                        }
                        //else
                        //    _row["＜    注   文   №     ＞"].ToString().Replace(".", "");
                    }
                    _dtbJuchuu.AcceptChanges();

                    //Delete first row
                    _dtbJuchuu.Rows[0].Delete();
                    #endregion

                    //2016/10/20
                    //Delete columns not use
                    #region Delete column not use

                    for (int i = _dtbJuchuu.Columns.Count - 1; i >= 0; i--)
                    {
                        if (_dtbJuchuu.Columns[i].ColumnName.ToString().Trim() == "＜      得   意   先       ＞" || _dtbJuchuu.Columns[i].ColumnName.ToString().Trim() == "納入" ||
                            _dtbJuchuu.Columns[i].ColumnName.ToString().Trim() == "＜       製   造   №        ＞")
                            _dtbJuchuu.Columns.RemoveAt(i);
                    }
                    #endregion

                    //2016/10/24
                    //Add new column
                    #region Add new column to Source DataTable
                    bool _flagExist = false;
                    foreach (DataColumn _col in _dtbJuchuu.Columns)
                    {
                        if (_col.ColumnName == "受注納期" || _col.ColumnName == "備考")
                        {
                            _flagExist = true;
                            break;
                        }
                        else
                            continue;
                    }
                    // If Dont have column name like "受注納期" or "備考"
                    // -> add new column for dataSource

                    if (!_flagExist)
                    {
                        DataColumn _colNouki = new DataColumn();
                        _colNouki.ColumnName = "受注納期";

                        DataColumn _colBikou = new DataColumn();
                        _colBikou.ColumnName = "備考";

                        _dtbJuchuu.Columns.Add(_colNouki);
                        _dtbJuchuu.Columns.Add(_colBikou);
                    }
                    dtgJuchuu.DataSource = _dtbJuchuu;
                    #endregion

                    foreach (DataGridViewColumn _dtgColumns in dtgJuchuu.Columns)
                    {
                        _dtgColumns.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }

                    //foreach (DataRow _row in _dtbJuchuu.Select())
                    //{
                    //    _row["＜    注   文   №     ＞"] = _row["＜    注   文   №     ＞"].ToString().Replace(".", "");
                    //}
                    _dtbJuchuu.AcceptChanges();
                    dtgJuchuu.DataSource = _dtbJuchuu;
                }
            }
            catch (Exception)
            {
                lblMessage.Text = "エラーがあります。出来ません。";
                lblMessage.ForeColor = Color.Red;
            }
        }

        private void 製品負荷を開くToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //2016/10/28 HonC Open file 製品負荷リスト
                OpenFileDialog _of = new OpenFileDialog();
                _of.Filter = "All Files (*.*)|*.*";
                _of.FilterIndex = 1;
                _of.Multiselect = false;

                if (_of.ShowDialog() == DialogResult.OK)
                {
                    _dtbSeihinFuka = Common.GetDataTable(_of.FileName);
                    dtgSeihin.DataSource = _dtbSeihinFuka;
                }
                tabControl1.SelectedTab = tbpSeihin;
                lblMessage.Text = "出来ました。";
                lblMessage.ForeColor = Color.Blue;
            }
            catch (Exception)
            {
                lblMessage.Text = "エラーがありますが。出来ません。";
                lblMessage.ForeColor = Color.Red;
            }
        }

        private void 部品負荷を開くToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //2016/10/28 HonC Open file 部品負荷リスト
                OpenFileDialog _of = new OpenFileDialog();
                _of.Filter = "All File (*.*)| *.*";
                _of.FilterIndex = 1;
                _of.Multiselect = false;

                if (_of.ShowDialog() == DialogResult.OK)
                {
                    _dtbBuhinFuka = Common.GetDataTable(_of.FileName);
                    dtgBuhin.DataSource = _dtbBuhinFuka;
                    lblMessage.Text = "";
                    lblMessage.ForeColor = Color.Blue;
                }
                tabControl1.SelectedTab = tbpBuhin;

            }
            catch (Exception)
            {
                lblMessage.Text = "エラーがありあますが。出来ません。";
                lblMessage.BackColor = Color.Red;
            }

        }
    }
}
