<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>

<body>
    <?php
    $list = array(1, 4, 4, 3, 7, 9, 6, 7, 6, 5, 5);

    function findDuplicates($list)
    {
        //Initiieren des Resultatarrays
        $resultSet = array();

        //Iterieren durch das gegebene Array
        for ($i = 0; $i < count($list); $i++) {
            //Der Index bleibt immer positiv
            $index = abs($list[$i]) - 1;

            //Wenn auf eine negative Zahl getroffen wird, dann wird dieser Verweis dem Resultat hinzugefügt
            if ($list[$index] < 0) {
                $resultSet[] = abs($list[$i]);
            } else {
                $list[$index] = -$list[$index];  //hier werden alle Zahlen ins Minus gesetzt und somit "markiert"
            }
        }
        // Anzeige des Resultats aller Duplikate
        foreach ($resultSet as $x) {
            echo "Duplikat: $x <br>";
        }

        return $resultSet;
    }
    findDuplicates($list);
    ?>
</body>

</html>