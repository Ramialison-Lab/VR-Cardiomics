# VR-Cardiomics

## Overview

VR-Cardiomics provides a framework to map multi-dimensional data (such as intensity and location of gene expression) onto 3D models in a heatmap-like manner. In our use case, the intensity is the level of gene expression of those expressed in the adult heart, and the location is this expression level in 18 discrete pieces of the heart as measured by RNA-seq.

Code for the manuscript: Denis Bienroth<sup>\*</sup>, Hieu T. Nim, Dimitar Garkov, Karsten Klein, Sabrina Jaeger-Honz, Mirana Ramialison<sup>#</sup> and Falk Schreiber<sup>#</sup>. "Spatially-Resolved Transcriptomics in ImmersiveEnvironments" (<sup>\*</sup>: first author; <sup>#</sup>: corresponding authors)

VR-Cardiomics is designed to map user-generated data onto a user-specific 3D model. However, the data and the model must meet certain requirements. Please refer to chapter [Upload Custom Data](#custom) for more information on how to use VR-Cardiomics as a framework for your own data and models on your local machine.

This application supports VR devices as listed [below](#dependencies), our [web application](https://github.com/Ramialison-Lab/3DCardiomics) and [zSpace](https://github.com/Ramialison-Lab/3DCardiomicsZSpace) are available as well.

## Navigate
- [Dependencies](#dependencies)
- [How to run VR-Cardiomics](#runVR)
- [VR-Cardiomics Features](#features)
- [Upload custom data](#custom)
- [Troubleshooting](#trouble)

## <a name="dependencies">Dependencies </a>

-   Unity (2019.4.19f1)

Currently fully supported VR devices include: 
-  	Oculus Quest / Quest 2 (Link mode)
-	Oculus Rift / Rift S 
Other devices may not be fully supported.

## <a name="runVR">How to run VR-Cardiomics </a>

The simplest way to run VR-Cardiomics is by using Unity [2019.4.19f1](https://unity3d.com/de/unity/whats-new/2019.4.19). Copy VR-Cardiomics from GitHub to your local machine ([how to copy from GitHub](https://docs.github.com/en/repositories/creating-and-managing-repositories/cloning-a-repository)) and open it in Unity (Information on how to open an existing project in Unity can be found [here](https://docs.unity3d.com/2019.1/Documentation/Manual/GettingStartedOpeningProjects.html)).

*It is recommended to ignore update notifications from Unity in order to ensure that the application is processed as expected.*

## <a name="features">VR-Cardiomics Features</a>

### <a name="menu">The menu </a>

The menu panel is used to control all features of VR-Cardiomics. It can be moved by grabbing the pink handle on the left side of the menu. The menu can be used by either touching the buttons directly or pointing to the button and clicking the *A* button of the primary Oculus Controller.

![menu_2](https://user-images.githubusercontent.com/79250095/134443158-cef43273-3223-4d7f-84a3-599a59c64b30.png)

Menu explanations:
1. Input field for expression value
2. Switch to current view
3. Enable/Disable the keyboard
4. Make an automated screenshot of the current object
5. Reset the environment
6. Switch to dataset selection menu
7. Switch to settings menu
8. Use the + or - buttons to add or remove objects to the environment
9. Export and Normalised/Absolute toggle button
10. Group Selection


### <a name="selectExpression">How to select an expression value </a>

1. By default one model will appear in the environment once the application is started. If no model appeared please [add a model](#addmodel) and [select it](#select).
2. Grab the [menu](#menu) panel and touch the input field or the keyboard button to enable the keyboard. The menu can be used by either touching the buttons directly or pointing on the button and clicking the *A* button of the primary of the Oculus Controller.
3. Enter the name of the expression that should be mapped onto the model. The keyboard can be used by either touching the button directly or pointing on the button and clicking the *X* button of the Oculus Controller.

https://user-images.githubusercontent.com/79250095/134448551-48a56437-dcbd-42c8-abf5-e7edf90579ef.mp4

### <a name="select">How to select a model</a>

By default the first model in the environment is selected. If new models will be added select them using the *highlighter function*. This function is enabled by pressing the *Y* Button of the secondary controller. A red illuminating circle will appear under the selected model. Press the *Y* button again to toggle to the next model. Press *A* on the primary controller to select the current model.

https://user-images.githubusercontent.com/79250095/134447783-f0fbcc7f-b97d-4747-908d-103cc33a71ca.mp4

### <a name="explode">Explode Function</a>
The explode function will expand the model based on its hierarchy. this feature might not work properly for custom objects. To toggle between the normal view and the exploded view press the *X* button on the secondary controller. Only the [selected model](#select) will be expanded.

![Screenshot (238)](https://user-images.githubusercontent.com/79250095/134447818-21544de8-5dd4-4689-834d-6c8a84e938db.png)

### <a name="addmodel">Add/Remove models</a>

VR-Cardiomics allows adding multiple objects to the environment to map expression data onto it. Use the [menu panel](#menu) to add or remove models by pressing either the + or the - button. Keep in mind that always the last model will be deleted once the - button is pressed. The number between the buttons shows how many active objects are currently in the surrounding.

https://user-images.githubusercontent.com/79250095/134448305-e560c958-9470-4d4a-9885-8e2b54f4ad0b.mp4

### Change between absolute and normalized expression values

VR-Cardiomics allows to present expression data either in absolute or in normalised values. Our example data is based on log2CPM values for absolute. If [own datasets](#custom) is used, the absolute values will represent the uploaded values of the csv file. Toggle between Normalised or Absolute by using the [menu panel (9)](#menu).

### How to use the heatmap comparison

The heatmap comparison is a useful feature to allow calculating the absolute differences of each piece of the object between two expression patterns. The feature will automatically calculate those differences and apply a new colourisation to the model regarding how big the differences in each selected piece are. To use the heatmap function just select an expression for two objects and then grab one model with the pink handle. Hold the pink handle onto the handle of a second heart model. Release the trigger Button to enable the heatmap feature.

https://user-images.githubusercontent.com/79250095/134449147-5b535342-94d6-43f2-9e9e-18d4f53ccc0e.mp4

### Export data/images

VR-Cardiomics allows to export data during runtime. 

1. **Making screenshots** → Simply use the Camera button of the [menu panel(4)](#menu). A Screenshot of the current selected heart model will be saved to your local machine. 
2. **Exporting Similar Expressions** → If an expression value is [selected](#selectExpression) a list of similar expressions will be calculated based on the selection. This list can be exported as a csv file using the export button on the [menu panel (9)](#menu). This CSV file is then saved in the Asset folder of Unity. (Figure: SimilarGenes.txt → blue).
3. **Logfile** → For each session a logfile will be created to keep track of everything you did during your session. This logfile is saved automatically on your local machine within the Assets folder of Unity (Figure: SessionLog.txt → green).

![exportFiles](https://user-images.githubusercontent.com/79250095/134449902-41210806-428f-4381-a907-b7e520b89ce5.png)

### <a name="switchDataset">Switch between datasets</a>

VR-Cardiomics allows uploading [own datasets](#custom) with expression values. You can also upload multiple datasets and switch between them during runtime. Therefore, navigate to the dataset menu by pressing the dataset button of the [menu panel(6)](#menu). Touching your pre-loaded dataset forces a reset of the environment with the new dataset being used. 

https://user-images.githubusercontent.com/79250095/134450769-7be16fa7-0056-41fb-aeaf-7ddb5b059641.mp4

### Piecewise Comparison / Group Selection

The *piecewise comparison/ group selection* is a feature that allows to group a number of pieces of the object together in two groups. Based on those two groups a list of expression values is generated matching the pattern of the selected pieces. 
To use this feature press the *group Selection* Button on the [menu panel(10)](#menu). All objects will be deleted except of one object. This object can be used to select the pieces of the first group. Just bring the controller at one piece and press the *A* button of the oculus controller to select the piece. The piece will be coloured to confirm the selection. continue with this step until all pieces of group 1 are selected. Now push the button of the [menu panel(10)](#menu) again to confirm the first group and start selecting new pieces for group 2. If the selection is done just press the button of the [menu panel(10)](#menu) again to confirm selection and start calculating the matching expression values. The results will be shown in the table below. 
To deselect pieces from the selection just select them anew.

https://user-images.githubusercontent.com/79250095/135013053-277ebcd8-6a62-445a-b468-9fe83173c376.mp4

### Additional features

- Reset the environment by touching the *reset* button of the [menu panel(5)](#menu)
- Enable or disable the keyboard by touching the *keyboard* button [menu panel(3)](#menu) or by touching the input field [menu panel(1)](#menu). The keyboard will always appear in front of the user.
- Open the settings by touching the *settings* button of the [menu panel(7)](#menu). 

## <a name="custom">Upload custom data </a>

VR-Cardiomics allows users to upload their own datasets or models. However, since VR-Cardiomics is still a work in progress, certain requirements of the datasets as well as the objects are expected.

### Upload datasets

VR-Cardiomics allows to upload datasets in csv format. Either as csv or txt files. In order to switch between the datasets, please see chapter [Switch between datasets](#switchDataset). To use this feature, the datasets need to be pre-uploaded. Please follow the following instructions:

**Change dataset in editor**
1. Open VR-Cardiomics in the [Unity editor](#runVR).
2. Navigate to ```Assets\Resources```
3. press right click and select *Import New Asset*
4. Browse your local machine and select the dataset to be uploaded

![image](https://user-images.githubusercontent.com/79250095/135014485-b13facb0-ed8d-4046-932d-4d7052fc1bdd.png)

**Change dataset in Windows**
1. Simply navigate to the gitub source code of *VR-Cardiomics** on your local machine.
2. Navigate to ```..\VR-Cardiomics\Assets\Resources```
3. Copy the dataset into the directory

**Customise valid names**

In order to allow VR-Cardiomics to recognise the items of your dataset, please customise the file *valid_names.txt*. This file contains all valid names, which in our case match the example data of *fake_mouse_expression_data8*. the file contains all gene names of MGI version 9. If you want to run VR-Cardiomics as a framework for other datasets, please replace this file with a file containing all the items of your dataset. 

**Example files and structure of datasets**
This version of *VR-Cardiomics* comes with sample data to use. The dataset is stored in ```Assets\Resources\fake_mouse_expression.txt```. A snippet of the dataset is shown here:
![image](https://user-images.githubusercontent.com/79250095/135015941-16cef151-9b09-4a66-ad2a-860888ff798b.png)

Each line of a customised dataset must start with the items name, followed by exactly 18 expression values in csv format, due to the current limitations as explained below.
Once the dataset and the *valid_names* are customised, open the file ```Assets\Currentfile.txt``` and replace the name with the filename of your dataset (without endings such as .txt) (blue frame) or select the **ScriptHolder** Object in the **Hierarchy** tab and replace the name in the *CSV Name* field in the *Colour(Script)* in the *Inspector* tab (green frame).

![csvName](https://user-images.githubusercontent.com/79250095/135016348-44577ed7-4620-4b22-a2f8-a25257aa9dd2.png)


**Current limitations of the dataset**
VR-Cardiomics is a work in progress. We developed it to use it on a 18 section slices heart model. Therefore, currently only datasets and models with exactly 18 slices are able to be used within the environment. We will take care of this limitation and to allow variable datasets and models as soon as possible.

### Upload 3D model

VR-Cardiomics uses a heart model which is sliced into 18 pieces. This object can be used with this GitHub code. The model can be viewed in ```Assets/Resources``` It is saved as a prefab in Unity. For more information on prefabs in Unity visit [this site](https://docs.unity3d.com/Manual/Prefabs.html). 
To upload a heart model, follow these steps:
1. Navigate to the folder ```Assets/Resources``` and press right click and select *Import New Asset*. 
2. Browse your local machine and select the model you wish to upload.
3. Drag and Drop (green arrow) the model from the prefab folder to the *inspector* tab into the field *Model Prefab* of the *Object Manager (Script)*. The name of the object will be shown in the selection.

![selectObject](https://user-images.githubusercontent.com/79250095/135017216-5566bd2b-db89-4d90-b73b-36d6dc532ab0.png)

**Limitations to objects**

VR-Cardiomics is a work in progress. We developed it to use it on a 18 section slices heart model. Therefore, currently only datasets and models with exactly 18 slices are able to be used within the environment. We will take care of this limitation and to allow variable datasets and models as soon as possible.

Please ensure that the model you are going to upload meets the following requirements:
1. The object must be in a unity compatible format such as .obj
2. The object needs to have a top layer (orange)
3. The object needs to have exactly five slices (green) due to our limitations, with the names Slice_A, Slice_B, Slice_C, Slice_D and Slice_E. The slices will also be used for the [explode-feature](#explode). Otherwise, if this feature is not required or your model doesn’t meet a slices hierarchy just divide the objects under the Slices as in the example object. This will not have any effect on the calculation of the values or the visualisation.
4. The Object needs exactly 18 pieces (blue). These pieces need to have the names as shown in the example. (A_1, A_2 ... E_3). Please divide your objects and name them accordingly.

**Interaction with the pieces** 
Unity is based on physics. To allow the user to grab single pieces as shown in our example, each piece (A_1, A_2 ... E_3) has to have certain physics and scripts attached. Currently it is not possible to attach those scripts automatically during runtime due to a Unity problem. Therefore, if you wish to interact with the single pieces as shown in the following figure, you need to attach certain scripts to each of the 18 objects first. This step is optional, the environment works without those scripts and the objects can still be moved in total by using the pink handles of each object.

![SinglePiece](https://user-images.githubusercontent.com/79250095/135018942-c07c7a2c-f387-47ff-af8d-d3b71e1cde6a.png)

Follow these instructions to allow single piece interaction:

1. Mark all the pieces of the object named A_1, A_2 ... E_3 and ensure that the Slices are not marked.
![image](https://user-images.githubusercontent.com/79250095/135019408-f108d6d5-7cc4-46f5-a9ac-777774b1995f.png)
2. In the *inspector* tab click the *Add Component* Button on the end of the list and type *OVR Grabbable*. Select the file below and it will be added to all objects.
![image](https://user-images.githubusercontent.com/79250095/135019585-026110bb-fcf0-4b43-bc55-846fa5bfd082.png)
3. Again mark all objects as explained in 1. and click *Add Component*. This time type *Rigidbody* and select it from the list. A Component *Rigidbody* will be added to all objects. While all objects are still marked please ensure that the boxes are ticked as the following:
![image](https://user-images.githubusercontent.com/79250095/135019795-ea703042-5de5-4664-91bd-dd797c7601d0.png)
4. Repeat step 1 to mark all objects and type *Mesh Collider*, select the Mesh Collider Component to add it to the objects. While all objects are still marked please ensure that the boxes are ticked as the following:
![image](https://user-images.githubusercontent.com/79250095/135019904-f1436767-be4b-48bc-9a09-f8ac502c3e42.png)



![structureObject](https://user-images.githubusercontent.com/79250095/135017833-b74eaf05-3040-4d76-a6d4-6773305bd359.png)


## <a name="trouble">Troubleshooting </a>
### Oculus Quest/ Quest2
The Oculus Quest and Quest 2 can be used in [Oculus Link](https://www.oculus.com/blog/play-rift-content-on-quest-with-oculus-link-available-now-in-beta/?locale=de_DE) mode. This allows those devices to be treated like an Oculus Rift in wired mode to run the application on your local machine rather than on the device itself.  

### VR not working
- If the VR-Headset isn't recognized properly please navigate in Unity from Edit → Project Settings → Player and ensure that *Virtual Reality Supported* is ticked.![VRsupported](https://user-images.githubusercontent.com/79250095/134309050-125952d3-bf16-464e-8f67-9a88e76fb381.png)

- Ensure that Unity runs on the correct platform. Therefore, navigate from File → Build Settings → PC, Mac & Linux Standalone. 
![switchBuild](https://user-images.githubusercontent.com/79250095/134440181-bfbc741d-b01a-4f4d-9bad-ec1d46fe02c3.png)
If the marked Button doesn't appear press the *switch platform* Button.

- VR-Cardiomics is currently only tested for Oculus Rift/ Rift S and Oculus Quest and Quest 2 in link mode. Although, the used plugins allow devices such as HTC Vive to be used they are not tested and therefore not supported. Using those devices might led to errors while running the application.
