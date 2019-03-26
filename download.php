<?php

require 'config.php';

if (!isset($_SESSION['id'])) {
die("I'm sorry, this page is for logged in AMO students only.");
    }
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
    <style>
        body{
            text-align: center;
        }
        .downloadLink{
            display: block;
            background-color: #4CAF50;
            padding-top: 12px;
            padding-bottom: 12px;
            font-size: 1.7em;
            color: darkgreen;
        }
    </style>
</head>
<body>
    <div class="container">
        <div class="imgcontainer">
            <img src="img/banner.png" alt="Avatar" class="avatar">
        </div>
        <h2>download page</h2>
        <p>
            dit is de downloadpagina van de hondenrace. druk op de onderstaande knop om de download te starten.
        </p>
        <a href="dogRace/dogRace/bin/Debug/dogRace.exe" download class="downloadLink">download</a>
    </div>
</body>
