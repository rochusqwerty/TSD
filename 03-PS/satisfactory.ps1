Function CPU(){
    $text = Get-Process | Where-Object {$_.cpu -GE 10} | Format-Table Name, CPU -AutoSize
    $text > 'file.txt'
}

Function MSDN(){
    $regex = '.*?PowerShell.*?'
    $i = 0
    foreach($line in Get-Content .\MSDN.txt) {
        if($line -match $regex){
            Write-Host $i $line
        }
        $i = $i + 1
    }
}

Function RSS(){
    $regex = '<title>(?<content>.*)</title>'
    foreach($line in Get-Content .\PowerShell.rss) {
        if($line -match $regex){
            Write-Host $matches['content']
        }
    }
}

#I tried to do it in other way but it doesn't work
Function RSS1(){
    $xml = [xml](get-content PowerShell.rss)
    #$xml.Load('PowerShell.rss')
    $regex = '<item>\W*<title>(?<content>.*)</title>'
    $line = Get-Content .\PowerShell.rss
    $line -match $regex
    Write-Host $matches
    foreach($m in $matches) {
            Write-Host "cos"
        
    }
        
    
}