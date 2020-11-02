# Define AudioDevice by ID
$AudioDevice_A = "{0.0.0.00000000}.{adbbf8cc-ea02-42f0-be77-f98bbde5ae07}" #Speakers
$AudioDevice_B = "{0.0.0.00000000}.{c9adcbc6-54ed-46d2-9d76-21663330f4a2}" #Headset

# Toggle default playback device
$DefaultPlayback = Get-AudioDevice -Playback
If ($DefaultPlayback.ID -eq $AudioDevice_A) {Set-AudioDevice -ID $AudioDevice_B | Out-Null}
Else {Set-AudioDevice -ID $AudioDevice_A | Out-Null}