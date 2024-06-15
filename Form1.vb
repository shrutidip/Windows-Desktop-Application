Imports System.IO

Public Class Form1
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ' Display message box in Form1's constructor
        MessageBox.Show("Shruti, this is my Slidely AI task")
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Form Styling
        Me.BackColor = Color.LightBlue
        Me.Font = New Font("Arial", 12, FontStyle.Bold)
        Me.FormBorderStyle = FormBorderStyle.FixedSingle

        ' Add Labels and Textboxes for User Input
        Dim nameLabel As New Label()
        nameLabel.Text = "Name:"
        nameLabel.Location = New Point(50, 50)
        Dim nameTextBox As New TextBox()
        nameTextBox.Location = New Point(150, 50)
        nameTextBox.Name = "TextBox1" ' Ensure it matches the validation logic

        Dim emailLabel As New Label()
        emailLabel.Text = "Email:"
        emailLabel.Location = New Point(50, 100)
        Dim emailTextBox As New TextBox()
        emailTextBox.Location = New Point(150, 100)
        emailTextBox.Name = "TextBox2" ' Ensure it matches the validation logic

        Me.Controls.Add(nameLabel)
        Me.Controls.Add(nameTextBox)
        Me.Controls.Add(emailLabel)
        Me.Controls.Add(emailTextBox)

        ' Add Submit Button and Event Handler
        Dim submitButton As New Button()
        submitButton.Text = "Submit"
        submitButton.Location = New Point(150, 150)
        submitButton.Name = "Button1" ' Ensure it matches the dynamic removal logic
        submitButton.Size = New Size(120, 40) ' Set button size to 120x40 pixels
        AddHandler submitButton.Click, AddressOf SubmitButton_Click
        Me.Controls.Add(submitButton)
    End Sub

    Private Sub SubmitButton_Click(sender As Object, e As EventArgs)
        ' Data Validation
        If String.IsNullOrWhiteSpace(Me.Controls("TextBox1").Text) OrElse Not Me.Controls("TextBox2").Text.Contains("@") Then
            MessageBox.Show("Please enter valid name and email.")
            Return
        End If

        ' Display Collected Information
        Dim message As String = $"Name: {Me.Controls("TextBox1").Text}{Environment.NewLine}Email: {Me.Controls("TextBox2").Text}"
        MessageBox.Show(message)

        ' Persistence - Save to File
        Dim fileName As String = "user_info.txt"
        Using writer As New StreamWriter(fileName)
            writer.WriteLine(message)
        End Using

        ' Dynamic Controls - Remove Submit Button
        Me.Controls.Remove(Me.Controls("Button1"))

        ' Advanced MessageBox
        Dim result = MessageBox.Show("Do you want to close the application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ' Save form settings or data before closing
    End Sub

    Private Async Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ' Multithreading - Background Task
        Await Task.Run(Sub()
                           ' Simulating a time-consuming operation
                           Threading.Thread.Sleep(5000)
                           MessageBox.Show("Background task completed.")
                       End Sub)
    End Sub
End Class
