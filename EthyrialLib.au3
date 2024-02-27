#RequireAdmin
#include-once
#include "NomadMemory.au3"

#Region memory
Func MemoryOpen()
EndFunc

Func MemoryClose()
EndFunc

Func WriteBinary

Func MemoryWrite

Func MemoryRead

Func MemoryReadPtr

#End Region

#Region Initialization 
Func ScanEthyrial()
Local $processName = "Ethyrial.exe"
Local $processArray = ProcessList($processName)
If $processArray[0][0] = 0 Then
    MsgBox(0, "Error", "Game process not found.")
    Exit
EndIf
$processHandle = _MemoryOpen($processArray[1][1])

$questAddress = 0x1EB35A9EB78 ; The memory address for the "Tyrants" quest
$questAvailableValue = 1 ; The value to make the quest available

; Write the value to the address
_MemoryWrite($questAddress, $processHandle, $questAvailableValue, "byte")

_MemoryClose($processHandle)
