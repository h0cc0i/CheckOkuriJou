using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace AutoCheckAndSendReport
{
    public partial class CheckOkuriJou : Form
    {
        #region Define variable
        System.Data.DataTable _dtbSource;
        System.Data.DataTable _dtbDes = new System.Data.DataTable();
        System.Data.DataTable _dtbExtend = new System.Data.DataTable();
        #endregion
        //buon ngu vl  sao ko update nhi
        public CheckOkuriJou()
        {
            InitializeComponent();
            Shown += CheckOkuriJou_Shown;
        }

        private void openFileSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog _of = new OpenFileDialog();
                _of.Filter = "All Files (*.*)|*.*";
                _of.FilterIndex = 1;
                _of.Multiselect = false;
                if (_of.ShowDialog() == DialogResult.OK)
                {
                    _dtbSource = Common.GetDataTable(_of.FileName);
                    for (int i = _dtbSource.Columns.Count - 1; i >= 0; i--)
                    {
                        if (!string.IsNullOrEmpty(_dtbSource.Rows[0][i].ToString()))
                        {
                            _dtbSource.Columns[i].ColumnName = _dtbSource.Rows[0][i].ToString();
                        }
                        else
                        {
                            //delete null columns
                            _dtbSource.Columns.RemoveAt(i);
                        }
                    }
                    _dtbSource.Rows[0].Delete();
                    _dtbSource.AcceptChanges();
                    //  MessageBox.Show("col5:" + _dtbSource.Columns[5].ColumnName.ToString()+ "col6" + _dtbSource.Columns[6].ColumnName.ToString());
                    MessageBox.Show("Import Excel 出来ました。", "お知らせ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtChumon.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void txtZumen_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void CheckOkuriJou_Load(object sender, EventArgs e)
        {
            try
            {
                _dtbDes.Columns.Add("受注No", typeof(string));
                _dtbDes.Columns.Add("図面番号", typeof(string));
                _dtbDes.Columns.Add("受注数", typeof(string));
                _dtbDes.Columns.Add("受注単価", typeof(string));
                _dtbDes.Columns.Add("受注金額", typeof(string));
                _dtbDes.Columns.Add("注文No", typeof(string));
                _dtbDes.Columns.Add("受注納期", typeof(string));
                _dtbDes.Columns.Add("備考", typeof(string));

                dtgOkuri.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dtgOkuri.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dtgOkuri.Columns[0].Width = 50;

                Common._main = this;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnExportOkuriJou_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog _sfd = new SaveFileDialog();
                _sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                _sfd.FilterIndex = 2;
                _sfd.RestoreDirectory = true;
                if (_sfd.ShowDialog() == DialogResult.OK)
                {
                    // 20161115 HonC export to Excel
                    string _NewPath = _sfd.FileName + "送り状";
                    DataSet ds = new DataSet("Ahihi");
                    //ds.Tables.Clear();
                    ds.Tables.Add(_dtbDes.Copy());
                    Common.DtbToExcel(ds, _sfd.FileName.ToString() + ".xlsx");
                    ds.Dispose();
                    // FormatExcel(_sfd.FileName.ToString() + ".xlsx");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラーがあります。出力出来ません。", "お知らせ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                //kill all process !!!
                var processes = from p in Process.GetProcessesByName("EXCEL")
                                select p;

                foreach (var process in processes)
                {
                    if (process.ProcessName == "EXCEL")
                        process.Kill();
                }
            }
        }

        private void ExportDataSetToExcel(DataSet ds, string _Path)
        {
            //Creae an Excel application instance
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

            //Create an Excel workbook instance and open it from the predefined location
            Microsoft.Office.Interop.Excel.Workbook excelWorkBook = excelApp.Workbooks.Open(_Path);

            foreach (System.Data.DataTable table in ds.Tables)
            {
                //Add a new worksheet to workbook with the Datatable name
                Microsoft.Office.Interop.Excel.Worksheet excelWorkSheet = excelWorkBook.Sheets.Add();
                excelWorkSheet.Name = table.TableName;

                for (int i = 1; i < table.Columns.Count + 1; i++)
                {
                    excelWorkSheet.Cells[1, i] = table.Columns[i - 1].ColumnName;
                }

                for (int j = 0; j < table.Rows.Count; j++)
                {
                    for (int k = 0; k < table.Columns.Count; k++)
                    {
                        excelWorkSheet.Cells[j + 2, k + 1] = table.Rows[j].ItemArray[k].ToString();
                    }
                }
            }

            excelWorkBook.Save();
            excelWorkBook.Close();
            excelApp.Quit();

        }

        private void dtgOkuri_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtChumon_KeyDown(object sender, KeyEventArgs e)
        {
            //2016/11/07 When Home -> Go to Search View
            if (e.KeyData == Keys.Home)
            {
                if ((_dtbSource != null) && (_dtbSource.Rows.Count > 0))
                {
                    // clear main form data
                    ClearData(false);

                    // Go to Seach Form
                    if (Common._search == null)
                    {
                        Common._search = new FrmSearchData(_dtbSource);
                    }
                    Common._search.Show();

                }
            }
        }

        // get data from Search form
        public void GetData(_info _temp)
        {
            txtChumon.Text = _temp.Chuumon;
            txtJuchu.Text = _temp.Juchuu;
            txtZumen.Text = _temp.Zumen;
            txtKazu.Text = _temp.Kazu;
            txtTanKa.Text = _temp.Tanka;
            txtJuchuuNoki.Text = _temp.JuchuNoki;
            txtKingaku.Text = _temp.Kingaku;

            txtJuchu.Enabled = false;
            txtZumen.Enabled = false;
            txtKazu.Enabled = false;
            txtTanKa.Enabled = false;
            txtJuchuuNoki.Enabled = false;
            txtKingaku.Enabled = false;

            btnKakunin.Focus();
        }

        private void btnKakunin_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    //add to dataTableSource            => add item in list source
                    DataRow _row = _dtbDes.NewRow();
                    _row["注文No"] = txtChumon.Text.Trim();
                    _row["受注No"] = txtJuchu.Text.Trim();
                    _row["図面番号"] = txtZumen.Text.Trim();
                    _row["受注数"] = txtKazu.Text.Trim();
                    _row["受注単価"] = txtTanKa.Text.Trim();
                    _row["受注金額"] = txtKingaku.Text.Trim(); ;
                    _row["受注納期"] = txtJuchuuNoki.Text.Trim();
                    _row["備考"] = txtBiKou.Text.Trim();

                    //Check duplicate before insert
                    if ((_dtbDes.Rows.Count > 0) && Check図面Duplicate(txtZumen.Text, _dtbDes))
                    {
                        MessageBox.Show("図面があるんですがご確認ください。");
                    }
                    else
                    {
                        _dtbDes.Rows.InsertAt(_row, 0);
                        //_dtbDes.Rows.Add(_row);
                        dtgOkuri.DataSource = _dtbDes;
                        lbldtgCount.Text = "全て：" + dtgOkuri.Rows.Count.ToString() + "ケ";
                    }

                }

                //set focus
                txtChumon.Focus();
                txtChumon.SelectAll();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData(true);
            txtChumon.Focus();
        }

        public void ClearData(bool _Enable)
        {
            txtZumen.Text = string.Empty;
            txtTanKa.Text = string.Empty;
            txtKingaku.Text = string.Empty;
            txtKazu.Text = string.Empty;
            txtJuchuuNoki.Text = string.Empty;
            txtJuchu.Text = string.Empty;
            txtChumon.Text = string.Empty;
            txtBiKou.Text = string.Empty;

            txtZumen.Enabled = _Enable;
            txtTanKa.Enabled = _Enable;
            txtKingaku.Enabled = _Enable;
            txtJuchu.Enabled = _Enable;
            txtKazu.Enabled = _Enable;
            txtJuchuuNoki.Enabled = _Enable;
            //txtChumon.Enabled = _Enable;
        }

        private void dtgOkuri_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dtgOkuri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    DialogResult _dlg = MessageBox.Show("決したい？", "確認", MessageBoxButtons.YesNo);
                    if (_dlg == DialogResult.Yes)
                    {
                        //Indexでセルを消します。
                        _dtbDes.Rows[e.RowIndex].Delete();
                        _dtbDes.AcceptChanges();
                        dtgOkuri.DataSource = _dtbDes;
                        MessageBox.Show("完了しました。");
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("エラーがあります。");
            }
        }

        private void btnPrintExcel_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

                MessageBox.Show("エラーがあります。印刷出来ません。", "お知らせ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CheckOkuriJou_Shown(object sender, EventArgs e)
        {
            try
            {
                if (Common._Current != null)
                {
                    //  GetData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 20161117 Spring 
        /// </summary>
        /// <param name="_path"></param>
        public void FormatExcel(string _path)
        {
            //Creae an Excel application instance
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook excelWorkBook = excelApp.Workbooks.Open(_path);
            Microsoft.Office.Interop.Excel.Workbook objBook = excelApp.Workbooks.Add(System.Reflection.Missing.Value);
            //Get the First sheet.
            Microsoft.Office.Interop.Excel.Worksheet objSheet = (Microsoft.Office.Interop.Excel.Worksheet)objBook.Sheets[1];
            objSheet.get_Range("A2", "H" + _dtbDes.Rows.Count.ToString()).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;


            excelApp.DisplayAlerts = false;
            objBook.SaveAs(_path, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, true, false, XlSaveAsAccessMode.xlNoChange, XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);
            objBook.Close();
            excelApp.Quit();
        }

        public bool Check図面Duplicate(string _Zumen, System.Data.DataTable _dtb)
        {
            _dtb.DefaultView.RowFilter = string.Format("図面番号 LIKE '%{0}%'", _Zumen);
            if (_dtb.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}
