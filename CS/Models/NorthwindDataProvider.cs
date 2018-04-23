using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Web.Configuration;

public class NorthwindDataProvider {
    public static IEnumerable GetCategories() {
        List<Category> categories = new List<Category>();

        using (OleDbConnection connection = new OleDbConnection(WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString)) {
            OleDbCommand selectCommand = new OleDbCommand("SELECT * FROM Categories", connection);

            connection.Open();

            OleDbDataReader reader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection);

            while (reader.Read()) {
                categories.Add(new Category() {
                    CategoryID = (int)reader["CategoryID"],
                    CategoryName = (string)reader["CategoryName"],
                    Description = (string)reader["Description"]
                });
            }

            reader.Close();
        }

        return categories;
    }

    public static IEnumerable GetProducts() {
        List<Product> products = new List<Product>();
            
        using (OleDbConnection connection = new OleDbConnection(WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString)) {
            OleDbCommand selectCommand = new OleDbCommand("SELECT * FROM Products ORDER BY ProductID", connection);

            connection.Open();

            OleDbDataReader reader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection);

            while (reader.Read()) {
                products.Add(new Product() {
                    ProductID = (int)reader["ProductID"],
                    ProductName = (string)reader["ProductName"],
                    UnitPrice = (reader["UnitPrice"] == DBNull.Value ? null : (decimal?)reader["UnitPrice"]),
                    UnitsOnOrder = (reader["UnitsOnOrder"] == DBNull.Value ? null : (short?)reader["UnitsOnOrder"]),
                    CategoryID = (reader["CategoryID"] == DBNull.Value ? null : (int?)reader["CategoryID"]),
                });
            }

            reader.Close();
        }

        return products;
    }

    public static string GetCategoryDescriptionById(int CategoryID) {
        string result = string.Empty;
        
        using (OleDbConnection connection = new OleDbConnection(WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString)) {
            OleDbCommand selectCommand = new OleDbCommand("SELECT Description FROM Categories WHERE CategoryID = " + CategoryID.ToString(), connection);
            connection.Open();
            result = selectCommand.ExecuteScalar() as string;
            connection.Close();
        }

        return result;
    }
}
