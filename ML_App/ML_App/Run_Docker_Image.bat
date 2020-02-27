docker load --input Docker_Image/mlappImage.tar

docker run -v %cd%/Input/:/app/Input/ -t --name appcontainer mlapp

docker cp appcontainer:/app/Output/ScoredOutput.txt %cd%/Output/ScoredOutput.txt

pause