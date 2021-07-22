# 3D-cardiomics-VR

## Overview

3D-Cardiomics provides a framework to map multi dimensional data (such as intensity and location of gene expression) on to 3D models in a heatmap-like manner in VR. In our use case the intensity is the level of gene expression of those expressed in the adult heart, and the location is this expression level in 18 discrete pieces of the heart as measured by RNA-seq. 

## Supported Devices

Currently fully supported VR devices include:

* Oculus Quest / Quest 2
* Oculus Rift / Rift S

Other devices may not be fully supported.


## Upload Files

Gene Expressions are stored under the following path

```
Assets/Resources/
```

A sample of fake gene expressions is provided at:

```
Assets/Resources/fake_mouse_expression_data.txt
```

In order to change expression data, import *.txt* file in Ressources folder. The expression data can simply be changed by using the *Scriptholder* Object in Unity. The attached Script *Colour* stores the datapath of the csv file named *CSV name*. Enter the name of the csv file within ressource strucutre or corresponding datapath if stored otherwise.

![CSVpath](https://user-images.githubusercontent.com/79250095/126587353-91838b1c-c559-4013-af3b-3e2313960c66.PNG)

## Dependencies 

* Unity 2019.4.19f1 

## Instructions
Start Unity 2019.4.19f1 or later on the whole folder structure of the gitHub Repo. For using the Oculus Quest or Quest 2 please allow the device to access Rift library in order to use it with data cable. Otherwise export project to android database in order to load it onto device. 


