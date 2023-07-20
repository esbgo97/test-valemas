<?php
function multiplicarArreglo($num, $arreglo){
    return array_map(function($item) use($num){
        return $item * $num;
    },$arreglo);
}

$numero = 2;
$numeros = [1,2,3];
$result = multiplicarArreglo($numero,$numeros);

print_r($result);

?>