<?php
$sql = "SELECT * FROM accounts ";
?>
<!doctype html>
<html class="no-js" lang="">

<head>
    <meta charset="utf-8">
    <meta http-equiv="x-ua-compatible" content="ie=edge">
    <title></title>
    <meta name="description" content="">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <link rel="manifest" href="site.webmanifest">
    <link rel="apple-touch-icon" href="icon.png">
    <!-- Place favicon.ico in the root directory -->

    <link rel="stylesheet" href="css/normalize.css">
    <link rel="stylesheet" href="css/main.css">
</head>

<body>
<!--[if lte IE 9]>
<p class="browserupgrade">You are using an <strong>outdated</strong> browser. Please <a href="https://browsehappy.com/">upgrade your browser</a> to improve your experience and security.</p>
<![endif]-->

<!-- Add your site or application content here -->

<main>
    <div class="container">
        <h1>De Gokker</h1>

        <form action="login.php">
            <div class="imgcontainer">
                <img src="img/banner.png" alt="Avatar" class="avatar">
            </div>

            <div class="info-degokker">
                <h2>Welkom bij onze website!</h2>
                <p>Hier ken je ons game de gokker vinden. We hopen dat je de game leuk ga vinden! De game gaat
                    over een honderace. Je kan alleen spelen of met vrienden!
                </p>
            </div>

            <button type="submit" onclick="window.location.href='$login.php'">druk om in te loggen</button>

    </div>
</main>
<script src="js/vendor/modernizr-3.6.0.min.js"></script>
<script src="https://code.jquery.com/jquery-3.3.1.min.js" integrity="sha256-FgpCb/KJQlLNfOu91ta32o/NMZxltwRo8QtmkMRdAu8=" crossorigin="anonymous"></script>
<script>window.jQuery || document.write('<script src="js/vendor/jquery-3.3.1.min.js"><\/script>')</script>
<script src="js/plugins.js"></script>
<script src="js/main.js"></script>

<!-- Google Analytics: change UA-XXXXX-Y to be your site's ID. -->
<script>
    window.ga = function () { ga.q.push(arguments) }; ga.q = []; ga.l = +new Date;
    ga('create', 'UA-XXXXX-Y', 'auto'); ga('send', 'pageview')
</script>
<script src="https://www.google-analytics.com/analytics.js" async defer></script>

<?php
if (isset($_GET['msg'])) {
    $msg = 'Mail is al in gebruik.';
    echo "<script>alert('$msg')</script>";
}
?>
</body>

</html>


<?php require 'footer.php'; ?>
