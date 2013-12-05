using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace FOR_FEMALE
{
    public partial class Form1 : Form
    {

        public enum CalcuType
        {
            None,
            /// <summary>
            /// 加法
            /// </summary>
            Addition,
            /// <summary>
            /// 減法
            /// </summary>
            Substraction,
            /// <summary>
            /// 乘法
            /// </summary>
            Multiplication,
            /// <summary>
            /// 除法
            /// </summary>
            Division,
            /// <summary>
            /// 乘方
            /// </summary>
            Involution,
            /// <summary>
            /// 開方
            /// </summary>
            Square,
        }

        private double? _ValueF = null;
        private double? _ValueL = null;
        private CalcuType _CalculateType = CalcuType.None;
        private bool _IsNew = false;
        private double? _StoredValue = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnVal1.Click += new EventHandler(btnVal_Click);
            btnVal2.Click += new EventHandler(btnVal_Click);
            btnVal3.Click += new EventHandler(btnVal_Click);
            btnVal4.Click += new EventHandler(btnVal_Click);
            btnVal5.Click += new EventHandler(btnVal_Click);
            btnVal6.Click += new EventHandler(btnVal_Click);
            btnVal7.Click += new EventHandler(btnVal_Click);
            btnVal8.Click += new EventHandler(btnVal_Click);
            btnVal9.Click += new EventHandler(btnVal_Click);
            btnVal0.Click += new EventHandler(btnVal_Click);
            btnDot.Click += new EventHandler(btnVal_Click);
        }
        private void btnVal_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string numberStr = this.txtValue.Text;
            if (this._IsNew)
            {
                numberStr = btn.Text;
                this._ValueL = double.Parse(numberStr);
            }
            else
            {

                if (new string[] { "0", "0.", "-0", "-0.", }.Contains(numberStr))
                {
                    numberStr = "";
                }
                numberStr += btn.Text;
                this._ValueF = double.Parse(numberStr);
            }

            this.txtValue.Text = numberStr;
            this._IsNew = false;
        }

        private void txtValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnPI_Click(object sender, EventArgs e)
        {
            if (this._IsNew)
            {
                this._ValueL = Math.PI;
            }
            else
            {
                this._ValueF = Math.PI;
            }
            this.txtValue.Text = Math.PI.ToString();
            this._IsNew = true;
        }






        private void btnResult_Click(object sender, EventArgs e)
        {
            switch (_CalculateType)
            {
                case CalcuType.Addition:
                    this.txtValue.Text = (_ValueF + _ValueL).ToString();
                    break;
                case CalcuType.Substraction:
                    this.txtValue.Text = (_ValueF - _ValueL).ToString();
                    break;
                case CalcuType.Multiplication:
                    this.txtValue.Text = (_ValueF * _ValueL).ToString();
                    break;
                case CalcuType.Division:
                    if (_ValueL == 0)
                    {
                        this.txtValue.Text = "除數不能爲零!";
                    }
                    else
                    {
                        this.txtValue.Text = (_ValueF / _ValueL).ToString();
                    }
                    break;
                case CalcuType.Involution:
                    this.txtValue.Text = Math.Pow((double)_ValueF, (double)_ValueL).ToString();
                    break;
                case CalcuType.Square:
                    this.txtValue.Text = Math.Pow((double)_ValueF, 1 / (double)_ValueL).ToString();
                    break;
            }
            this._ValueF = double.Parse(this.txtValue.Text);
            this._IsNew = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this._ValueL = null;
            this._ValueF = null;
            this._CalculateType = CalcuType.None;
            this.txtValue.Text = "0.";
        }

        private void btnAddition_Click(object sender, EventArgs e)
        {
            this.btnResult_Click(sender, e);
            this._CalculateType = CalcuType.Addition;
            this._IsNew = true;
        }

        private void btnSubstraction_Click(object sender, EventArgs e)
        {
            this.btnResult_Click(sender, e);
            this._CalculateType = CalcuType.Substraction;
            this._IsNew = true;
        }

        private void btnMultiplication_Click(object sender, EventArgs e)
        {
            this.btnResult_Click(sender, e);
            this._CalculateType = CalcuType.Multiplication;
            this._IsNew = true;
        }

        private void btnDivision_Click(object sender, EventArgs e)
        {
            this.btnResult_Click(sender, e);
            this._CalculateType = CalcuType.Division;
            this._IsNew = true;
        }

        private void btnSquare_Click(object sender, EventArgs e)
        {
            this.btnResult_Click(sender, e);
            this._CalculateType = CalcuType.Square;
            this._IsNew = true;
        }

        private void btnInvelution_Click(object sender, EventArgs e)
        {
            this.btnResult_Click(sender, e);
            this._CalculateType = CalcuType.Involution;
            this._IsNew = true;
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if (this.txtValue.Text.Length == 1)
            {
                this.txtValue.Text = "0.";
            }
            else
            {
                this.txtValue.Text = txtValue.Text.Substring(0, txtValue.Text.Length - 1);
            }
        }

        private void btnMC_Click(object sender, EventArgs e)
        {
            this._StoredValue = null;
            this.lblM.Text = "";
        }

        private void btnMR_Click(object sender, EventArgs e)
        {
            if (_StoredValue == null)
            {
                return;
            }
            if (this._IsNew)
            {
                this._ValueL = this._StoredValue;
            }
            else
            {
                this._ValueF = this._StoredValue;
            }
            this.txtValue.Text = this._StoredValue.ToString();
            this._IsNew = true;
        }

        private void btnMS_Click(object sender, EventArgs e)
        {
            try
            {
                this._StoredValue = double.Parse(this.txtValue.Text);
                this.lblM.Text = "M";
            }
            catch (Exception)
            {
            }
        }

        private void btnMPlus_Click(object sender, EventArgs e)
        {
            try
            {
                if (this._StoredValue == null)
                {
                    this._StoredValue = double.Parse(this.txtValue.Text);
                }
                else
                {
                    this._StoredValue += double.Parse(this.txtValue.Text);
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnSubst_Click(object sender, EventArgs e)
        {
            try
            {
                if (this._StoredValue == null)
                {
                    this._StoredValue = double.Parse(this.txtValue.Text);
                }
                else
                {
                    this._StoredValue -= double.Parse(this.txtValue.Text);
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (txtValue.Text == ".")
                txtValue.Text = "0.";
            _ValueL = Convert.ToDouble(txtValue.Text);
            btnClear = null;
        }
    }
}
