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
    public partial class FrmSearchData : Form
    {
        _info _Current = new _info();
        DataTable _dtbtemp = new DataTable();

        public FrmSearchData()
        {
            InitializeComponent();
        }

        public FrmSearchData(DataTable _dtb)
        {
            InitializeComponent();
            if (_dtb.Rows.Count > 0)
            {
                _dtbtemp = _dtb;
                //  dtgListSource.DataSource = _dtb;
            }
            //dtgListSource.Columns["図面番号"].Width = 150;
            //dtgListSource.Columns["注文№"].Width = 150;
            //dtgListSource.Columns["受注納期"].Width = 150;
        }

        private void FrmSearchData_Load(object sender, EventArgs e)
        {
            try
            {
                Common._search = this;
                txtChuumon.Text = string.Empty;
                txtJuchuu.Text = string.Empty;
                txtZuban.Text = string.Empty;
                //  (dtgListSource.DataSource as DataTable).DefaultView.RowFilter = string.Format(" 注文№ LIKE '%{0}%' AND 受注№ LIKE '%{1}%' AND 図面番号 LIKE '%{2}%'", txtChuumon.Text.Trim(), txtJuchuu.Text.Trim(), txtZuban.Text.Trim());
                dtgListSource.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtChuumon_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (dtgListSource.DataSource as DataTable).DefaultView.RowFilter = string.Format(" 注文№ LIKE '%{0}%' AND 注文№ LIKE '%{1}%' AND 図面番号 LIKE '%{2}%'", txtChuumon.Text.Trim(), txtJuchuu.Text.Trim(), txtZuban.Text.Trim());
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void txtZuban_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (dtgListSource.DataSource as DataTable).DefaultView.RowFilter = string.Format(" 注文№ LIKE '%{0}%' AND 受注№ LIKE '%{1}%' AND 図面番号 LIKE '%{2}%'", txtChuumon.Text.Trim(), txtJuchuu.Text.Trim(), txtZuban.Text.Trim());
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void txtJuchuu_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (dtgListSource.DataSource as DataTable).DefaultView.RowFilter = string.Format(" 注文№ LIKE '%{0}%' AND 受注№ LIKE '%{1}%' AND 図面番号 LIKE '%{2}%'", txtChuumon.Text.Trim(), txtJuchuu.Text.Trim(), txtZuban.Text.Trim());
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void txtChuumon_KeyDown(object sender, KeyEventArgs e)
        {
            //set value is equal first row in datagridview
            try
            {
                switch (e.KeyData)
                {
                    case Keys.Enter:
                        {
                            if (dtgListSource.Rows.Count > 0)
                            {
                                //set first first row is result
                                if (txtChuumon.Text != dtgListSource.Rows[0].Cells["注文№"].Value.ToString() || (txtJuchuu.Text != dtgListSource.Rows[0].Cells["受注№"].Value.ToString()))
                                {
                                    txtChuumon.Text = dtgListSource.Rows[0].Cells["注文№"].Value.ToString();
                                    txtJuchuu.Text = dtgListSource.Rows[0].Cells["受注№"].Value.ToString();
                                    txtZuban.Text = dtgListSource.Rows[0].Cells["図面番号"].Value.ToString();
                                }
                                else
                                {
                                    //go to main form
                                    Common._main.GetData(GetCurrentInfo());
                                    setDefaultData();
                                    Common._main.Show();
                                    this.Hide();
                                }
                            }
                            else
                            {
                                MessageBox.Show("データをもう一度チェックしていただけますか");
                            }
                            break;
                        }
                    case Keys.F5:
                        {
                            SearchDataSelect(txtChuumon.Text.Trim(), txtJuchuu.Text.Trim(), txtZuban.Text.Trim());
                            break;
                        }
                    case Keys.Escape:
                        {
                            if (string.IsNullOrEmpty(txtChuumon.Text) && string.IsNullOrEmpty(txtJuchuu.Text) && (string.IsNullOrEmpty(txtZuban.Text)))
                            {
                                this.Hide();
                            }
                            else
                            {
                                txtChuumon.Text = string.Empty;
                                txtJuchuu.Text = string.Empty;
                                txtZuban.Text = string.Empty;
                                lblCount.Text = string.Empty;
                                dtgListSource.DataSource = null;
                            }

                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtZuban_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                switch (e.KeyData)
                {
                    case Keys.Enter:
                        {
                            if (dtgListSource.Rows.Count > 0)
                            {
                                if (txtChuumon.Text != dtgListSource.Rows[0].Cells["注文№"].Value.ToString() || (txtJuchuu.Text != dtgListSource.Rows[0].Cells["受注№"].Value.ToString()))
                                {
                                    txtChuumon.Text = dtgListSource.Rows[0].Cells["注文№"].Value.ToString();
                                    txtJuchuu.Text = dtgListSource.Rows[0].Cells["受注№"].Value.ToString();
                                    txtZuban.Text = dtgListSource.Rows[0].Cells["図面番号"].Value.ToString();
                                }
                                else
                                {
                                    //set for _info
                                    GetCurrentInfo();
                                    Common._Current = GetCurrentInfo();

                                    //go to main form
                                    Common._main.GetData(GetCurrentInfo());
                                    setDefaultData();
                                    this.Hide();
                                }
                            }
                            else
                            {
                                MessageBox.Show("データをもう一度チェックしていただけませんか");
                            }
                            break;
                        }
                    case Keys.F5:
                        {
                            SearchDataSelect(txtChuumon.Text.Trim(), txtJuchuu.Text.Trim(), txtZuban.Text.Trim());
                            break;
                        }
                    case Keys.Escape:
                        {
                            if (string.IsNullOrEmpty(txtChuumon.Text) && string.IsNullOrEmpty(txtJuchuu.Text) && string.IsNullOrEmpty(txtZuban.Text))
                            {
                                this.Hide();
                            }
                            else
                            {
                                txtChuumon.Text = string.Empty;
                                txtJuchuu.Text = string.Empty;
                                txtZuban.Text = string.Empty;
                                lblCount.Text = string.Empty;
                                dtgListSource.DataSource = null;
                            }
                            break;
                        }
                    default:
                        break;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtJuchuu_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyData)
                {
                    case Keys.Enter:
                        {
                            if (dtgListSource.Rows.Count > 0)
                            {
                                if (txtChuumon.Text == dtgListSource.Rows[0].Cells["注文№"].Value.ToString() || (txtJuchuu.Text != (dtgListSource.Rows[0].Cells["受注№"].Value.ToString())))
                                {
                                    txtChuumon.Text = dtgListSource.Rows[0].Cells["注文№"].Value.ToString();
                                    txtJuchuu.Text = dtgListSource.Rows[0].Cells["受注№"].Value.ToString();
                                    txtZuban.Text = dtgListSource.Rows[0].Cells["図面番号"].Value.ToString();
                                }
                                else
                                {
                                    //set for _info
                                    GetCurrentInfo();
                                    Common._Current = GetCurrentInfo();
                                    //go to main form
                                    Common._flagHide = true;
                                    setDefaultData();
                                    this.Hide();
                                }
                            }
                            else
                            {
                                MessageBox.Show("データをもう一度チェックしていただけませんか");
                            }

                            break;
                        }
                    case Keys.F5:
                        {
                            SearchDataSelect(txtChuumon.Text.Trim(), txtJuchuu.Text.Trim(), txtZuban.Text.Trim());
                            break;
                        }
                    case Keys.Escape:
                        {
                            if (string.IsNullOrEmpty(txtChuumon.Text) && (string.IsNullOrEmpty(txtJuchuu.Text)) && (string.IsNullOrEmpty(txtZuban.Text)))
                            {
                                this.Hide();
                            }
                            else
                            {
                                txtChuumon.Text = string.Empty;
                                txtJuchuu.Text = string.Empty;
                                txtZuban.Text = string.Empty;
                                lblCount.Text = string.Empty;
                                dtgListSource.DataSource = null;
                            }
                            break;
                        }
                    default:
                        break;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public _info GetCurrentInfo()
        {
            _info _infoTemp = new _info();
            _infoTemp.Juchuu = dtgListSource.Rows[0].Cells["受注№"].Value.ToString();
            _infoTemp.Chuumon = dtgListSource.Rows[0].Cells["注文№"].Value.ToString();
            _infoTemp.Zumen = dtgListSource.Rows[0].Cells["図面番号"].Value.ToString();
            _infoTemp.Kazu = dtgListSource.Rows[0].Cells["受注残数"].Value.ToString();
            _infoTemp.Kingaku = dtgListSource.Rows[0].Cells["受注金額"].Value.ToString();
            _infoTemp.Tanka = dtgListSource.Rows[0].Cells["受注単価"].Value.ToString();
            _infoTemp.JuchuNoki = dtgListSource.Rows[0].Cells["受注納期"].Value.ToString();
            return _infoTemp;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void FrmSearchData_Shown(object sender, EventArgs e)
        {
            try
            {
                txtChuumon.Text = string.Empty;
                txtJuchuu.Text = string.Empty;
                txtZuban.Text = string.Empty;
                (dtgListSource.DataSource as DataTable).DefaultView.RowFilter = string.Format(" 注文№ LIKE '%{0}%' AND 受注№ LIKE '%{1}%' AND 図面番号 LIKE '%{2}%'", txtChuumon.Text.Trim(), txtJuchuu.Text.Trim(), txtZuban.Text.Trim());
                dtgListSource.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 20161116 HonC Clear Data Search and Default View
        /// </summary>
        public void setDefaultData()
        {
            txtChuumon.Text = string.Empty;
            txtJuchuu.Text = string.Empty;
            txtZuban.Text = string.Empty;
            dtgListSource.DataSource = null;
            lblCount.Text = string.Empty;

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                setDefaultData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 2016/11/16 HonC 
        /// Search Data in DataTable by LinQ
        /// </summary>
        /// <param name="_ChuuMon"> from txtChumon</param>
        /// <param name="_Juchuu">from txtJuchuu</param>
        /// <param name="_Zuban">from Zuban</param>
        public void SearchDataSelect(string _ChuuMon, string _Juchuu, string _Zuban)
        {
            if (_dtbtemp.Select(" 注文№ LIKE '%" + _ChuuMon + "%' AND 受注№ LIKE '%" + _Juchuu + "%' AND 図面番号 LIKE '%" + _Zuban + "%'").Count<DataRow>() > 0)
            {
                lblCount.Text = "全て：" + _dtbtemp.Select(" 注文№ LIKE '%" + _ChuuMon + "%' AND 受注№ LIKE '%" + _Juchuu + "%' AND 図面番号 LIKE '%" + _Zuban + "%'").Count<DataRow>().ToString() + "　ケ";
                DataTable _result = _dtbtemp.Select(" 注文№ LIKE '%" + _ChuuMon + "%' AND 受注№ LIKE '%" + _Juchuu + "%' AND 図面番号 LIKE '%" + _Zuban + "%'").CopyToDataTable();
                dtgListSource.DataSource = _result;
            }

        }

        private void FrmSearchData_Shown_1(object sender, EventArgs e)
        {
            
        }
    }
}

