using Terminal.Gui;

namespace RPG.Console;

// Defines a top-level window with border and title
public class ExampleWindow : Window
{
    public TextField UsernameText;

    public ExampleWindow()
    {
        Title = "Example App (Ctrl+Q to quit)";

        // Create input components and labels
        var usernameLabel = new Label()
        {
            Text = "Username:"
        };

        UsernameText = new TextField("")
        {
            // Position text field adjacent to the label
            X = Pos.Right(usernameLabel) + 1,

            // Fill remaining horizontal space
            Width = Dim.Fill(),
        };

        var passwordLabel = new Label()
        {
            Text = "Password:",
            X = Pos.Left(usernameLabel),
            Y = Pos.Bottom(usernameLabel) + 1
        };

        var passwordText = new TextField("")
        {
            Secret = true,
            // align with the text box above
            X = Pos.Left(UsernameText),
            Y = Pos.Top(passwordLabel),
            Width = Dim.Fill(),
        };

        // Create login button
        var btnLogin = new Button()
        {
            Text = "Login",
            Y = Pos.Bottom(passwordLabel) + 1,
            // center the login button horizontally
            X = Pos.Center(),
            IsDefault = true,
        };

        // When login button is clicked display a message popup
        btnLogin.Clicked += () => {
            if (UsernameText.Text == "admin" && passwordText.Text == "password")
            {
                MessageBox.Query("Logging In", "Login Successful", "Ok");
                Application.RequestStop();
            }
            else
            {
                MessageBox.ErrorQuery("Logging In", "Incorrect username or password", "Ok");
            }
        };

        // Add the views to the Window
        Add(usernameLabel, UsernameText, passwordLabel, passwordText, btnLogin);
    }
}