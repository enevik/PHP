<?php
require 'config.php';
/*
 * Dit is een webserver only script, waar je alleen mag komen als je via een form
 * data verstuurd, en niet als je via de url hier naar toe komt. Iedereen die dat doet
 * sturen we terug naar index.php
 *
 */
if ($_SERVER['REQUEST_METHOD'] !== 'POST' ) {
    header('location: index.php');
    exit;
}

if ( $_POST['type'] === 'login' ) {
    /*var_dump($_POST);*/

    $email = $_POST['email'];
    $password = $_POST['password'];

    $user_login_email_check_query = $db->prepare("SELECT * FROM accounts WHERE email=?");
    $user_login_email_check_query->execute([$email]);
    $account = $user_login_email_check_query->fetch();
    if ($account) {
        // email has been found

        $sql = "SELECT * FROM accounts WHERE email = :email";
        $prepare = $db->prepare($sql);
        $prepare->execute([
            ':email' => $email
        ]);
        $account = $prepare->fetch(PDO::FETCH_ASSOC);

        $storedPassword = $account['password'];

        if ($account) {

            $hashedPassword = $account['password'];
//            $isThePasswordCorrect = password_verify($hashedPassword, PASSWORD_DEFAULT);

            if (password_verify($password, $storedPassword)){
                // everything is oke
                echo "everything is oke";

                $id = $account['id'];
                $_SESSION['id'] = $id;
                header( 'location: admin.php');
            }
            else {
                // wrong password try again.

                echo "wrong password try again.";
            }

        } else {
            // account not found redirect to register page.
            echo "password not found";
        }

    } else {
        // account not found redirect to register page.
        echo "email not found";
    }


    exit;

    /*
     * Hier komen we als we de login form data versturen.
     * things to do:
     * 1. Checken of gebruikersnaam EN email in de database bestaat met de ingevoerde data
     * 2. Indien ja, een $_SESSION['id'] vullen met de id van de persoon die probeert in te loggen.
     * 3. gebruiker doorsturen naar de admin pagina
     *
     * 3. Indien nee, gebruiker terugsturen naar de login pagina met de melding dat gebruikersnaam en/of
     * wachtwoord niet in orde is.
     *
     */
    exit;
}



if ($_POST['type'] === 'register') {

    $email = htmlentities( $_POST ['email']);
    $password = htmlentities($_POST ['password']);
    $password1 = htmlentities($_POST ['password1']);

    // $password = str_replace(' ', '', $password);     (dit doet het zelfde als trim() functie op volgende regel)
    // $password1 = str_replace(' ', '', $password1);   (dit doet het zelfde als trim() functie op volgende regel)
    $password = trim($password);
    $password1 = trim($password1);


    if (!filter_var($email, FILTER_VALIDATE_EMAIL)){
        header('location: index.php');
    }

    $sql = "SELECT `email` FROM `accounts` WHERE `email` = :email;";
    $prepare = $db->prepare($sql);
    $prepare->execute([
        ':email' => $email
    ]);
    $fetchedEmail = $prepare->fetchAll(PDO::FETCH_ASSOC);

    if($fetchedEmail == true){
        $msg = 'Sorry deze email is al in gebruik.';
        header("location:index.php?msg=$msg");
        $msg = htmlspecialchars($_GET['msg']);
        exit;
    }



    if($password == $password1) {
        $sql = "INSERT INTO accounts (email, password) VALUE(:email, :password)";

        $password = password_hash($password, PASSWORD_DEFAULT);

        $prepare = $db->prepare($sql);
        $prepare->execute([
            ':email' => $email,
            ':password' => $password
        ]);



        header('location: index.php');
        exit;
    }
    else{
        echo "wachtwoord komt niet overheen";
    }

    /*
     * Hier komen we als we de register form data versturen
     * things to do:
     *
     * 1. Checken of er al iemand met dit emailadres of username bestaat
     * 2. Indien nee, eerst checken of de password en password_confirm inderdaad hetzelfde ingevoerde is.
     * 3. Dan gebruiker inserten in de database, zodat deze kan gaan inloggen.
     * 4. Gebruiker doorsturen naar de nieuwe inlog pagina.
     *
     * 5. Indien ja, gebruiker terugsturen naar register form met de melding dat gebruikersnaam en/of wachtworod niet op
     * orde is.
     *
     *
     */
}






