Minimum project necessary to show performance issue using Skia library on linux container to convert .eml to .pdf.

You need a dev express API key to create the docker image. Check the dockerfile.

You should change the Main() function to reference your test .eml file. For testing on linux container, it is easiest to just place the .eml file in the project root folder as everything is copied over to the image. 
