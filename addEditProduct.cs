﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PcFirma
{
    public partial class addEditProduct : Form
    {
        private DataSet _userSet;
        private SqlDataAdapter _adapter;
        private SqlConnection connection;

        private Dictionary<string, int> categories = new Dictionary<string, int>();
        private Dictionary<string, int> countries = new Dictionary<string, int>();
        private Dictionary<string, int> brands = new Dictionary<string, int>();

        private DataSet _userSetForDic;
        private SqlDataAdapter _adapterForDic;

        private DataSet _userSetForDicBr;
        private SqlDataAdapter _adapterForDicBr;

        string selectCategories;
        public addEditProduct()
        {
            InitializeComponent();
        }
        public addEditProduct(int id, DataSet dataset, SqlDataAdapter adapter, SqlConnection connection)
        {
            InitializeComponent();
            _userSetForDic = new DataSet();
            selectCategories = "SELECT * FROM Counrties";
            _adapterForDic = new SqlDataAdapter(selectCategories, connection);
            _adapterForDic.Fill(_userSetForDic);

            foreach (DataRow categoryRow in _userSetForDic.Tables[0].Rows)
            {
                countries.Add(categoryRow["Country"].ToString(),
                    Convert.ToInt32(categoryRow["Id"]));
            }
            ComboBoxCountry.DataSource = countries.Keys.ToList();

            _userSetForDic = new DataSet();
            selectCategories = "SELECT * FROM Categories";
            _adapterForDic = new SqlDataAdapter(selectCategories, connection);
            _adapterForDic.Fill(_userSetForDic);

            foreach (DataRow categoryRow in _userSetForDic.Tables[0].Rows)
            {
                categories.Add(categoryRow["CategoryName"].ToString(),
                    Convert.ToInt32(categoryRow["CategoryID"]));
            }
            ComboBoxCategory.DataSource = categories.Keys.ToList();
        }
        

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void baclButton_Click(object sender, EventArgs e)
        {
            groupBox6.Visible = true;
            addButton.Visible = false;
            baclButton.Visible = false;
            groupBox7.Visible = false;
            groupBox6.Visible = true;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(ComboBoxBrand.Text) || String.IsNullOrEmpty(ComboBoxCategory.Text) || String.IsNullOrEmpty(ComboBoxCountry.Text))
            {
                StatusPol.Visible = true;
                StatusPol.Text = "Fill all fields";
            }
            else
            {
                groupBox6.Visible = false;
                addButton.Visible = true;
                baclButton.Visible = true;
                groupBox7.Visible = true;
            }
            
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(ComboBoxBrand.Text) || String.IsNullOrEmpty(ComboBoxCategory.Text) || String.IsNullOrEmpty(ComboBoxCountry.Text)||
                String.IsNullOrEmpty(NameText.Text) || String.IsNullOrEmpty(ModelText.Text) || String.IsNullOrEmpty(PriceText.Text)||
                String.IsNullOrEmpty(StockText.Text))
            {
                StatusPol.Visible = true;
                StatusPol.Text = "Fill all fields";
                return;
                
            }
            Connection("SELECT * FROM Models;");
            bool moznoName = false;
            bool moznoModel = false;
            foreach (DataRow row1 in _userSet.Tables[0].Rows)
            {
                if (row1["Models"].ToString() == ModelText.Text)
                {
                    moznoModel = true;
                }
            }
            Connection("SELECT * FROM Products;");
            foreach (DataRow row1 in _userSet.Tables[0].Rows)
            {
                if (row1["ProductName"].ToString() == NameText.Text)
                {
                    moznoName = true;
                }
            }
            if (moznoModel)
            {
                StatusPol.Visible = true;
                StatusPol.Text = "This model already exists";
            }
            else if (moznoName)
            {
                StatusPol.Visible = true;
                StatusPol.Text = "This product name already exists";
            }
            else
            {
                Connection("SELECT * FROM Models;");
                DataRow newRow = _userSet.Tables[0].NewRow();
                newRow["Models"] = ModelText.Text;
                newRow["BrandID"] = ComboBoxBrand.SelectedIndex + 1;
                newRow["CountryID"] = ComboBoxCountry.SelectedIndex + 1;
                newRow["CategoryID"] = ComboBoxCategory.SelectedIndex + 1;
                _userSet.Tables[0].Rows.Add(newRow);
                SaveData();
                Connection("SELECT * FROM Models;");
                string a = ((int)_userSet.Tables[0].Rows[_userSet.Tables[0].Rows.Count - 1]["Id"]).ToString();
                Connection("SELECT * FROM Products;");

                DataRow newRow1 = _userSet.Tables[0].NewRow();
                newRow1["ProductName"] = NameText.Text;
                newRow1["ModelID"] = a;
                newRow1["Price"] = PriceText.Text;
                newRow1["Stock"] = StockText.Text;
                _userSet.Tables[0].Rows.Add(newRow1);
                SaveData();
                MessageBox.Show("You have successfully add");
                Close();
            }
        }

        private void SaveData()
        {
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(_adapter);
            _adapter.Update(_userSet);
        }

        private void AddBrand_Click(object sender, EventArgs e)
        {
            Connection("SELECT * FROM Brand;");
            addCountryCategoryCountry addCountryCategoryCountry = new addCountryCategoryCountry(1, _userSet, _adapter, connection);
            addCountryCategoryCountry.Show();
        }

        private void AddCategory_Click(object sender, EventArgs e)
        {
            Connection("SELECT * FROM Categories;");
            addCountryCategoryCountry addCountryCategoryCountry = new addCountryCategoryCountry(2, _userSet, _adapter, connection);
            addCountryCategoryCountry.Show();
        }

        private void AddCountry_Click(object sender, EventArgs e)
        {
            Connection("SELECT * FROM Counrties;");
            addCountryCategoryCountry addCountryCategoryCountry = new addCountryCategoryCountry(0, _userSet, _adapter, connection);
            addCountryCategoryCountry.Show();
            
        }
        private void Connection(string selectQuery)
        {
            DataClass s = new DataClass();
            connection = new SqlConnection(s.ConnectionString());
            connection.Open();
            _userSet = new DataSet();
            if (connection.State == System.Data.ConnectionState.Open)
            {
                _adapter = new SqlDataAdapter(selectQuery, connection);
                _adapter.Fill(_userSet);

            }
        }

        private void ComboBoxCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            brands.Clear();
            ComboBoxBrand.Text = null;
            DataClass s = new DataClass();
            int a = ComboBoxCountry.SelectedIndex+1;
            _userSetForDicBr = new DataSet();
            connection = new SqlConnection(s.ConnectionString());
            string selectCategoriesBr = "SELECT Brand.Id, Brand.Brand, Brand.CountryID FROM Brand WHERE Brand.CountryID = " + a.ToString()+";";
            _adapterForDicBr = new SqlDataAdapter(selectCategoriesBr, connection);
            _adapterForDicBr.Fill(_userSetForDicBr);

            foreach (DataRow categoryRow in _userSetForDicBr.Tables[0].Rows)
            {
                brands.Add(categoryRow["Brand"].ToString(),
                    Convert.ToInt32(categoryRow["Id"]));
            }
            ComboBoxBrand.DataSource = brands.Keys.ToList();
        }
    }
}