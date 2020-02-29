docker load --input Docker_Image/mlappImage.tar

docker run -it -v %cd%/Input/:/app/Input/ -t --name mlappcontainer mlapp

SET OutputFile="%cd%\Output\ScoredOutput.txt"
IF EXIST %OutputFile% DEL /F %OutputFile%

docker cp mlappcontainer:/app/Output/ScoredOutput.txt %cd%/Output/ScoredOutput.txt

pause