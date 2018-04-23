Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web.ASPxTreeList
Imports System.Collections

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Private Const selectedNodesKey As String = "selectedNodesKey"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        treeList.DataBind()
    End Sub


    Protected Sub atlSelection_DataBinding(ByVal sender As Object, ByVal e As EventArgs)
        TryCast(sender, ASPxTreeList).DataSource = CreateLeftListDataSource()
    End Sub
    Private Iterator Function CreateLeftListDataSource() As IEnumerable
        For i As Integer = 0 To 99
            Yield New With {Key .ItemId = i, Key .Code = "Code " & i, Key .Name = "Name " & i, Key .Description = "Description " & i, Key .ItemType = i Mod 3, Key .ParentId = i Mod 10, Key .Price = i * 10.00}
        Next i

    End Function

    Protected Sub treeList_CustomCallback(ByVal sender As Object, ByVal e As TreeListCustomCallbackEventArgs)
        Select Case e.Argument
            Case "Save"
                SaveSelection()
            Case "Restore"
                RestoreSelection()
        End Select
    End Sub

    Private Sub SaveSelection()
        Session(selectedNodesKey) = treeList.GetSelectedNodes().Select(Function(node) node.Key)

    End Sub
    Private Sub RestoreSelection()
        If Session(selectedNodesKey) Is Nothing Then
            Return
        End If
        Dim rowKeys = DirectCast(Session(selectedNodesKey), IEnumerable(Of String))
        Dim [iterator] = treeList.CreateNodeIterator()
        [iterator].Reset()

        Do While [iterator].Current IsNot Nothing
            [iterator].Current.Selected = rowKeys.Contains([iterator].Current.Key)
            [iterator].GetNext()
        Loop
    End Sub
End Class