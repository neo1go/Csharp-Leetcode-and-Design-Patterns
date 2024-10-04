<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>

<body>
    <?php
    $testSample = array(1, 4, 2, 0, 5, 6); // Größte Zahl darf nicht höher als die Länge des Arrays sein.
    
    function missingNumber($testSample)
    {
        // Die erwartete Summe aller Zahlen von 1 bis n+1 wobei 0 vermieden wird für die Summenberechnung
        $expectedSum = (count($testSample)) * (count($testSample) + 1) / 2;//Berechnung für die Summe bei der die Länge der Zahlenkette
        //die größte Zahl bestimmt.(n * n+1)/2 
    

        echo "die erwartete Array-Länge ist " . (count($testSample) + 1);
        echo "<br>";
        echo "die erwartete Summe aller Zahlen im Array ist $expectedSum";
        echo "<br>";

        // Die tatsächliche Summe aller Zahlen im Array
        $actualSum = array_sum($testSample);
        echo "die tatsächliche Zahl ist $actualSum";
        // Die fehlende Zahl ist die Differenz zwischen der erwarteten Summe und der tatsächlichen Summe
        $missingNumber = $expectedSum - $actualSum;

        // Gib die fehlende Zahl aus
        echo "<br> Die fehlende Zahl ist $missingNumber";
        return $missingNumber;
    }
    missingNumber($testSample);
    ?>
</body>

</html>