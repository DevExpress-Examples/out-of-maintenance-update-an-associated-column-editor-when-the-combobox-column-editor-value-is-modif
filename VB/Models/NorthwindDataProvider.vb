Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.OleDb
Imports System.Web.Configuration

Public Class NorthwindDataProvider
	Public Shared Function GetCategories() As IEnumerable
		Dim categories As New List(Of Category)()

		Using connection As New OleDbConnection(WebConfigurationManager.ConnectionStrings("Northwind").ConnectionString)
			Dim selectCommand As New OleDbCommand("SELECT * FROM Categories", connection)

			connection.Open()

			Dim reader As OleDbDataReader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection)

			Do While reader.Read()
				categories.Add(New Category() With {.CategoryID = DirectCast(reader("CategoryID"), Integer), .CategoryName = DirectCast(reader("CategoryName"), String), .Description = DirectCast(reader("Description"), String)})
			Loop

			reader.Close()
		End Using

		Return categories
	End Function

	Public Shared Function GetProducts() As IEnumerable
		Dim products As New List(Of Product)()

		Using connection As New OleDbConnection(WebConfigurationManager.ConnectionStrings("Northwind").ConnectionString)
			Dim selectCommand As New OleDbCommand("SELECT * FROM Products ORDER BY ProductID", connection)

			connection.Open()

			Dim reader As OleDbDataReader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection)

			Do While reader.Read()
                products.Add(New Product() With {.ProductID = DirectCast(reader("ProductID"), Integer), .ProductName = DirectCast(reader("ProductName"), String), .UnitPrice = (If(reader("UnitPrice") Is DBNull.Value, Nothing, CType(reader("UnitPrice"), Nullable(Of Decimal)))), .UnitsOnOrder = (If(reader("UnitsOnOrder") Is DBNull.Value, Nothing, CType(reader("UnitsOnOrder"), Nullable(Of Short)))), .CategoryID = (If(reader("CategoryID") Is DBNull.Value, Nothing, DirectCast(reader("CategoryID"), Integer?)))})
			Loop

			reader.Close()
		End Using

		Return products
	End Function

	Public Shared Function GetCategoryDescriptionById(ByVal CategoryID As Integer) As String
		Dim result As String = String.Empty

		Using connection As New OleDbConnection(WebConfigurationManager.ConnectionStrings("Northwind").ConnectionString)
			Dim selectCommand As New OleDbCommand("SELECT Description FROM Categories WHERE CategoryID = " & CategoryID.ToString(), connection)
			connection.Open()
			result = TryCast(selectCommand.ExecuteScalar(), String)
			connection.Close()
		End Using

		Return result
	End Function
End Class
