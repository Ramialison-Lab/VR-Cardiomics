# 3DheartProject

## Overview

3D-Cardiomics provides a framework to map multi dimensional data (such as intensity and location of gene expression) on to 3D models in a heatmap-like manner in VR. In our use case the intensity is the level of gene expression of those expressed in the adult heart, and the location is this expression level in 18 discrete pieces of the heart as measured by RNA-seq. 

## Important Files

Gene Expressions are stored under the following path

```
Assets/Resources/
```

A sample of fake gene expressions is provided under:

```
Assets/Resources/fake_mouse_expression_data.txt
```

In order to change expression data, import *.txt* file in Ressources folder. The expression data can simply be changed by using the *Scriptholder* Object in Unity. The attached Script *Colour* stores the datapath of the csv file named *CSV name*. Enter the name of the csv file within ressource strucutre or corresponding datapath if stored otherwise.

![CSVpath](https://user-images.githubusercontent.com/79250095/126587353-91838b1c-c559-4013-af3b-3e2313960c66.PNG)
