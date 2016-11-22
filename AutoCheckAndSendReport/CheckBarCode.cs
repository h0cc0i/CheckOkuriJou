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
    public partial class CheckBarCode : Form
    {
        DataTable _dtbSource;
        DataTable _dtbDes = new DataTable();
        DataTable _dtbDataCheck;
        public CheckBarCode()
        {
            InitializeComponent();
        }

        private void openSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog _of = new OpenFileDialog();
                _of.Filter = "All Files (*.*)|*.*";
                _of.FilterIndex = 1;
                _of.Multiselect = false;
                if (_of.ShowDialog() == DialogResult.OK)
                {
                    #region Set first row is name of columns

                    _dtbSource = Common.GetDataTable(_of.FileName);
                    int _col = _dtbSource.Columns.Count -1;
                    for (int i = _col; i >=0; i--)
                    {
                        if (!string.IsNullOrEmpty(_dtbSource.Rows[0][i].ToString()))
                        {
                            _dtbSource.Columns[i].ColumnName = _dtbSource.Rows[0][i].ToString();
                        }
                        else
                        {
                            _dtbSource.Columns.RemoveAt(i);
                            continue;
                        }
                    }
                    
                    if (_dtbSource.Rows.Count > 0)
                        _dtbSource.Rows[0].Delete();
                    #endregion
                 
                    _dtbSource.AcceptChanges();
                    dtgSource.DataSource = _dtbSource;
                    tabControl1.SelectedTab = tpJuchuuzan;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("エラーがあります。");
                MessageBox.Show(ex.ToString());
            }
        }

        private void CheckBarCode_Load(object sender, EventArgs e)
        {
            _dtbDes.Columns.Add("Code", typeof(string));
            _dtbDes.Columns.Add("ID", typeof(string));
            _dtbDes.Columns.Add("Quantity", typeof(string));
            txtKumiko.Focus();
            menuStrip1.BackColor = Color.LightSteelBlue;
        }

        
        private void txtKumiko_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    for (int i = 0; i < _dtbSource.Rows.Count; i++)
                    {
                        if (_dtbSource.Rows[i]["組込No"].ToString() == txtKumiko.Text)
                        {
                            DataRow _row = _dtbDes.NewRow();
                            _row["Code"] = _dtbSource.Rows[i]["組込No"].ToString();
                            _row["ID"] = _dtbSource.Rows[i]["図面番号"].ToString();
                            _row["Quantity"] = _dtbSource.Rows[i]["受 注 残 数"].ToString();
                            _dtbDes.Rows.Add(_row);
                            _dtbSource.Rows[i].Delete();
                        }
                    }
                    _dtbSource.AcceptChanges();
                    dtgSource.DataSource = _dtbSource;
                    dataGridView2.DataSource = _dtbDes;
                    txtKumiko.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void openDataCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog _of = new OpenFileDialog();
                _of.Filter = "All Files (*.*)|*.*";
                _of.FilterIndex = 1;
                _of.Multiselect = false;
                if (_of.ShowDialog() == DialogResult.OK)
                {
                    #region Set first row is name of columns

                    _dtbDataCheck = Common.GetDataTable(_of.FileName);
                    int _col = _dtbDataCheck.Columns.Count - 1;
                    for (int i = _col; i >= 0; i--)
                    {
                        if (!string.IsNullOrEmpty(_dtbDataCheck.Rows[0][i].ToString()))
                        {
                            _dtbDataCheck.Columns[i].ColumnName = _dtbDataCheck.Rows[0][i].ToString();
                        }
                        else
                        {
                            _dtbDataCheck.Columns.RemoveAt(i);
                            continue;
                        }
                    }

                    if (_dtbDataCheck.Rows.Count > 0)
                        _dtbDataCheck.Rows[0].Delete();
                    #endregion


                    _dtbSource.AcceptChanges();
                    _dtgDataCheck.DataSource = _dtbDataCheck;
                    tabControl1.SelectedTab = tpJuchuunouki;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("エラーがあります。");
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnSendMail_Click(object sender, EventArgs e)
        {

        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            
        }

        //#region Create new file excel

        ////Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

        ////Microsoft.Office.Interop.Excel.Workbook xlWorkbook = _excel.Workbooks.Add(1);
        //Workbook newWorkbook = _excel.Workbooks.Add(misValue);
        //Microsoft.Office.Interop.Excel.Worksheet newWorksheet = ((Microsoft.Office.Interop.Excel.Worksheet)newWorkbook.Worksheets[1]);

        //_excelworksheet.Copy(newWorksheet);

        //        #endregion
    }
}
