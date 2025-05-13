Minimum project necessary to show performance issue using Skia library on linux container to convert .eml to .pdf.

You need a dev express key to create the docker image. Check the dockerfile.

You should change the Main() function to reference your test .eml file. For testing on linux container, it is easiest to just place the .eml file in the project root folder as everything is copied over to the image. The file will then be in the root project directory on the docker image.

On completion, the program should print the time ellapsed for the conversion process. For the problem document, this is 8-10x slower than running on Windows. For other tested .eml files, the performance is within 10-20%.
