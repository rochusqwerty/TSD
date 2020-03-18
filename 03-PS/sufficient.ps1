function Multiply($a, $b) {
   return $a * $b }

Function Increment(){
    param(
        [Parameter(Mandatory=$true)][int]$number,
        [Parameter(Mandatory=$false)][int]$incrementValue
    )
    if($incrementValue){
        return $number + $incrementValue
    }
    else{
        return $number + 1
    }
}

Function Date(){
    return Get-Date -Format "dddd, MMMM dd, yyyy"
}

Function SortByName(){
    $results = ls | Select-Object -Property Name,Length | Sort-Object { [regex]::Replace($_.Name, '\d+', { $args[0].Value.PadLeft(20) }) }
    return $results
    
}

Function GroupByExtension (){
    return Get-ChildItem C:\Users\48603\Downloads -recurse | where-object {$_.length -gt 1048576} | Sort-Object extension | ft name -auto
    
}

Function BiggerThan1MB (){
    return Get-ChildItem C:\Users\48603\Downloads -recurse | where-object {$_.length -gt 1048576} | Sort-Object length | ft name, length -auto
    
}