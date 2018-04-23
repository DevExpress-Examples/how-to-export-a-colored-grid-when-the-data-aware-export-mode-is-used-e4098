Imports System.Web
Imports System.Data
Imports System.Data.OleDb
Imports System.Collections.Generic

Public Class MyModel

    Public Shared Function GetProducts() As DataTable
        Dim dataTableProducts As New DataTable()
        Using connection As OleDbConnection = GetConnection()
            Dim adapter As New OleDbDataAdapter(String.Empty, connection)
            adapter.SelectCommand.CommandText = "SELECT [ProductID], [ProductName], [CategoryID], [UnitPrice] FROM [Products]"
            adapter.Fill(dataTableProducts)
        End Using
        Return dataTableProducts
    End Function

    Private Shared Function GetConnection() As OleDbConnection
        Dim connection As New OleDbConnection()
        connection.ConnectionString = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}", HttpContext.Current.Server.MapPath("~/App_Data/nwind.mdb"))
        Return connection
    End Function

End Class

Public Class MyViewModel

    Private privateProducts As DataTable
    Public Property Products() As DataTable
        Get
            Return privateProducts
        End Get
        Set(ByVal value As DataTable)
            privateProducts = value
        End Set
    End Property
End Class