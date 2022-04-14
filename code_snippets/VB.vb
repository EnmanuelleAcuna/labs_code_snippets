' Namespaces importantes / de utilidad
Imports System.Data.SqlClient 
Imports System.Collections.Generic 

' Declaracion de propiedad/variable/atributo 
Dim list As new Ilist(of Type)
Dim list As New List(Of String) = New String() {"str1", "str2"}

' Events
Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click 
	' Code
End Sub

' Retry example
Dim retry as Boolean = True

While retry
   Try
      my_stream.Read(buffer, 0, read_len)
      retry = False
   Catch ex As System.IO.IOException
       If MessageBox.Show("try again?") = DialogResult.Retry Then
           retry = True
       Else
           retry = False
           Application.Exit() 'just abort, doesn't matter
       End If
   End Try
End While

' declaro el objeto MiConexion como una variable de módulo. 
' Cuando se instancie será la conexión con la base de datos 
Dim MiConexion As ADODB.Connection

' Instancio la conexión (ahora la conexión existe) 
Set MiConexión = New ADODB.Connection 