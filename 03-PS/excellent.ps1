<#
$array1 = 1..10000 | % { Get-Random -Minimum 0 -Maximum 100000 }
$array2 = 1..10000 | % { Get-Random -Minimum 0 -Maximum 100000 }


$array3 = New-Object System.Collections.ArrayList
1..10000 | % {
    $o = New-Object pscustomobject -Property @{totalCount = $_;}
    [Void] $array3.Add($o)
}

Function Sort1(){
    (Measure-Command {$array1 | Sort-Object TotalCount -descending}).TotalSeconds  
    Write-Host "123"
}


Function Sort2(){
    (Measure-Command {[array]::sort($array2)}).TotalSeconds  
    Write-Host "123"
}
#>

Function Comparison(){
    $array1 = 1..10000 | % { Get-Random -Minimum 0 -Maximum 10000 }
    $array2 = 1..10000 | % { Get-Random -Minimum 0 -Maximum 10000 }
    Write-Host "Sort-Object" (Measure-Command -Expression { $array1 = $array1 | Sort-Object }).TotalSeconds 
    Write-Host ".NET Sort" (Measure-Command -Expression { [array]::Sort($array2) }).TotalSeconds 
}