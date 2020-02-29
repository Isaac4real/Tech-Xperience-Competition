# Tech-Xperience-Competition
This repository is part of a Philips' competition that requires the development of an A.I. algorithm to accurately classify different images.


## How to Run the app
The procedure to run the application is very simple and straightforward. Nevertheless, the following steps are crucial:
1. The Docker image was uploaded using Git LFS (due to the github upload limit of only 100 mb). For that reason, and after 
downloading the repository using the option *Download Zip*, you will need to download the docker image individually. Just go inside 
*Tech-Xperience-Competition/ML_App/Docker_Image/* and download the file *mlappImage.tar* individually (~950 mb). After downloading
the *.tar* image, please make sure you place it inside the correct folder (*Docker_Image/*).  

2. After you download the whole repository, insert the validation images inside the folder *Tech-Xperience-Competition/ML_App/Input/*.  
3. Now you just need to run the batch file named *Run_Docker_Image.bat* which is in *Tech-Xperience-Competition/ML_App/*. 
(P.S.: This step basically executes some *Docker* commands. I am assuming you are running on a windows machine. If not, see the next
section to where I explain *docker* commands).  
4. Besides being displayed in the console application, the scored results will be written in a ,txt file named *ScoredOutput.txt* in
*Tech-Xperience-Competition/ML_App/Output/*.  

## Details on how to run the app
* You obviously need to have *Docker Desktop* installed on your machine to run the docker image.
* The batch file was made to make your life easier. But it assumes you are running on Windows. If not, here is an explanation of the
commands in it:  
   1. Load the image:  
      * *docker load --input Docker_Image/mlappImage.tar* 
   2. Run the image by creating a container and sending the validation images to it's respective place inside the container.  
      * **Windows CMD**: *docker run -it -v %cd%/Input/:/app/Input/ -t --name mlappcontainer mlapp*    
      * **Ubuntu or Windows Powershell**: *docker run -it -v ${PWD}/Input/:/app/Input/ -t --name mlappcontainer mlapp*   
   3. Export the .txt output from the container to the respective folder in the host machine.  
      * **Windows CMD**: *docker cp mlappcontainer:/app/Output/ScoredOutput.txt %cd%/Output/ScoredOutput.txt*    
      * **Ubuntu or Windows Powershell**: *docker cp mlappcontainer:/app/Output/ScoredOutput.txt ${PWD}/Output/ScoredOutput.txt*    
      
## Aditional Info
The above steps should be enough for you to run the application flawlessly. However, if for some reason you are facing an issue, 
please contact me at any time. Even if you are just curious to know how I built this solution. I would e very glad to answer any 
question.  
Thank you vey much!!

## Author
I'm Isaac Reis, a ML/AI enthusiast from Portugal.  
email: isaacisforreal@gmail.com  
LinkedIn: https://www.linkedin.com/in/isaacisforreal/  
YouTube chanel: https://www.youtube.com/channel/UC1vFQvk1dnhsh8Xon6tJhqw?view_as=subscriber
