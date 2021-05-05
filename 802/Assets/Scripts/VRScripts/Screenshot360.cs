using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Screenshot360 : MonoBehaviour
{
    public GameObject cam1;
    public Camera camera1;
    public GameObject cam2;
    public Camera camera2;
    public GameObject cam3;
    public Camera camera3;
    public GameObject cam4;
    public Camera camera4;

    public GameObject canvas;
    public int captureWidth = 1920;
    public int captureHeight = 1080;

    public enum Format { RAW, JPG, PNG, PPM };
    public Format format = Format.JPG;

    private string outputFolder;
    private Rect rect;
    private RenderTexture renderTexture;
    private Texture2D screenShot;
    private bool isProcessing;
    private int rnd = 0;
   // public Camera[] camera;

    private void Start()
    {
        outputFolder = Application.persistentDataPath + "/Screenshots/";
        if (!Directory.Exists(outputFolder))
        {
            Directory.CreateDirectory(outputFolder);
            Debug.Log("Save Path will be : " + outputFolder);
        }
    }

    private string CreateFileName(int width, int height)
    {
        //timestamp to append to the screenshot filename
        string timestamp = DateTime.Now.ToString("yyyyMMddTHHmmss");
        // use width, height, and timestamp for unique file 
        var filename = string.Format("{0}/screen{1}_{2}x{3}_{4}.{5}", outputFolder, rnd, width, height, timestamp, format.ToString().ToLower());
        // return filename
        return filename;
    }

    private void CaptureScreenshot()
    {
        canvas.SetActive(false);
        rnd = 1;
        isProcessing = true;
        // create screenshot objects
        if (renderTexture == null)
        {
            // creates off-screen render texture to be rendered into
            rect = new Rect(0, 0, captureWidth, captureHeight);
            renderTexture = new RenderTexture(captureWidth, captureHeight, 24);
            screenShot = new Texture2D(captureWidth, captureHeight, TextureFormat.RGB24, false);
        }
        // get main camera and render its output into the off-screen render texture created above

        cam1.SetActive(true);

        camera1.targetTexture = renderTexture;
        camera1.Render();
        // mark the render texture as active and read the current pixel data into the Texture2D
        RenderTexture.active = renderTexture;
        screenShot.ReadPixels(rect, 0, 0);
        // reset the textures and remove the render texture from the camera1 since were done reading the screen data
        camera1.targetTexture = null;
        RenderTexture.active = null;
        // get our filename
        string filename = CreateFileName((int)rect.width, (int)rect.height);
        // get file header/data bytes for the specified image format
        byte[] fileHeader = null;
        byte[] fileData = null;
        //Set the format and encode based on it
        if (format == Format.RAW)
        {
            fileData = screenShot.GetRawTextureData();
        }
        else if (format == Format.PNG)
        {
            fileData = screenShot.EncodeToPNG();
        }
        else if (format == Format.JPG)
        {
            fileData = screenShot.EncodeToJPG();
        }
        else //For ppm files
        {
            // create a file header - ppm files
            string headerStr = string.Format("P6\n{0} {1}\n255\n", rect.width, rect.height);
            fileHeader = System.Text.Encoding.ASCII.GetBytes(headerStr);
            fileData = screenShot.GetRawTextureData();
        }
        // create new thread to offload the saving from the main thread
        new System.Threading.Thread(() =>
        {
            var file = System.IO.File.Create(filename);
            if (fileHeader != null)
            {
                file.Write(fileHeader, 0, fileHeader.Length);
            }
            file.Write(fileData, 0, fileData.Length);
            file.Close();
            Debug.Log(string.Format("Screenshot Saved {0}, size {1}", filename, fileData.Length));
            isProcessing = false;
        }).Start();
        //Cleanup
        Destroy(renderTexture);
        renderTexture = null;
        screenShot = null;
        cam1.SetActive(false);


        rnd = 2;
        isProcessing = true;
        // create screenshot objects
        if (renderTexture == null)
        {
            // creates off-screen render texture to be rendered into
            rect = new Rect(0, 0, captureWidth, captureHeight);
            renderTexture = new RenderTexture(captureWidth, captureHeight, 24);
            screenShot = new Texture2D(captureWidth, captureHeight, TextureFormat.RGB24, false);
        }
        // get main camera and render its output into the off-screen render texture created above

        cam2.SetActive(true);

        camera2.targetTexture = renderTexture;
        camera2.Render();
        // mark the render texture as active and read the current pixel data into the Texture2D
        RenderTexture.active = renderTexture;
        screenShot.ReadPixels(rect, 0, 0);
        // reset the textures and remove the render texture from the camera1 since were done reading the screen data
        camera2.targetTexture = null;
        RenderTexture.active = null;
        // get our filename
        filename = CreateFileName((int)rect.width, (int)rect.height);
        // get file header/data bytes for the specified image format
        fileHeader = null;
        fileData = null;
        //Set the format and encode based on it
        if (format == Format.RAW)
        {
            fileData = screenShot.GetRawTextureData();
        }
        else if (format == Format.PNG)
        {
            fileData = screenShot.EncodeToPNG();
        }
        else if (format == Format.JPG)
        {
            fileData = screenShot.EncodeToJPG();
        }
        else //For ppm files
        {
            // create a file header - ppm files
            string headerStr = string.Format("P6\n{0} {1}\n255\n", rect.width, rect.height);
            fileHeader = System.Text.Encoding.ASCII.GetBytes(headerStr);
            fileData = screenShot.GetRawTextureData();
        }
        // create new thread to offload the saving from the main thread
        new System.Threading.Thread(() =>
        {
            var file = System.IO.File.Create(filename);
            if (fileHeader != null)
            {
                file.Write(fileHeader, 0, fileHeader.Length);
            }
            file.Write(fileData, 0, fileData.Length);
            file.Close();
            Debug.Log(string.Format("Screenshot Saved {0}, size {1}", filename, fileData.Length));
            isProcessing = false;
        }).Start();
        //Cleanup
        Destroy(renderTexture);
        renderTexture = null;
        screenShot = null;
        cam2.SetActive(false);


        rnd = 3;
        isProcessing = true;
        // create screenshot objects
        if (renderTexture == null)
        {
            // creates off-screen render texture to be rendered into
            rect = new Rect(0, 0, captureWidth, captureHeight);
            renderTexture = new RenderTexture(captureWidth, captureHeight, 24);
            screenShot = new Texture2D(captureWidth, captureHeight, TextureFormat.RGB24, false);
        }
        // get main camera and render its output into the off-screen render texture created above

        cam2.SetActive(true);

        camera3.targetTexture = renderTexture;
        camera3.Render();
        // mark the render texture as active and read the current pixel data into the Texture2D
        RenderTexture.active = renderTexture;
        screenShot.ReadPixels(rect, 0, 0);
        // reset the textures and remove the render texture from the camera1 since were done reading the screen data
        camera3.targetTexture = null;
        RenderTexture.active = null;
        // get our filename
        filename = CreateFileName((int)rect.width, (int)rect.height);
        // get file header/data bytes for the specified image format
        fileHeader = null;
        fileData = null;
        //Set the format and encode based on it
        if (format == Format.RAW)
        {
            fileData = screenShot.GetRawTextureData();
        }
        else if (format == Format.PNG)
        {
            fileData = screenShot.EncodeToPNG();
        }
        else if (format == Format.JPG)
        {
            fileData = screenShot.EncodeToJPG();
        }
        else //For ppm files
        {
            // create a file header - ppm files
            string headerStr = string.Format("P6\n{0} {1}\n255\n", rect.width, rect.height);
            fileHeader = System.Text.Encoding.ASCII.GetBytes(headerStr);
            fileData = screenShot.GetRawTextureData();
        }
        // create new thread to offload the saving from the main thread
        new System.Threading.Thread(() =>
        {
            var file = System.IO.File.Create(filename);
            if (fileHeader != null)
            {
                file.Write(fileHeader, 0, fileHeader.Length);
            }
            file.Write(fileData, 0, fileData.Length);
            file.Close();
            Debug.Log(string.Format("Screenshot Saved {0}, size {1}", filename, fileData.Length));
            isProcessing = false;
        }).Start();
        //Cleanup
        Destroy(renderTexture);
        renderTexture = null;
        screenShot = null;
        cam3.SetActive(false);

        rnd = 4;
        isProcessing = true;
        // create screenshot objects
        if (renderTexture == null)
        {
            // creates off-screen render texture to be rendered into
            rect = new Rect(0, 0, captureWidth, captureHeight);
            renderTexture = new RenderTexture(captureWidth, captureHeight, 24);
            screenShot = new Texture2D(captureWidth, captureHeight, TextureFormat.RGB24, false);
        }
        // get main camera and render its output into the off-screen render texture created above

        cam4.SetActive(true);

        camera4.targetTexture = renderTexture;
        camera4.Render();
        // mark the render texture as active and read the current pixel data into the Texture2D
        RenderTexture.active = renderTexture;
        screenShot.ReadPixels(rect, 0, 0);
        // reset the textures and remove the render texture from the camera1 since were done reading the screen data
        camera4.targetTexture = null;
        RenderTexture.active = null;
        // get our filename
        filename = CreateFileName((int)rect.width, (int)rect.height);
        // get file header/data bytes for the specified image format
        fileHeader = null;
        fileData = null;
        //Set the format and encode based on it
        if (format == Format.RAW)
        {
            fileData = screenShot.GetRawTextureData();
        }
        else if (format == Format.PNG)
        {
            fileData = screenShot.EncodeToPNG();
        }
        else if (format == Format.JPG)
        {
            fileData = screenShot.EncodeToJPG();
        }
        else //For ppm files
        {
            // create a file header - ppm files
            string headerStr = string.Format("P6\n{0} {1}\n255\n", rect.width, rect.height);
            fileHeader = System.Text.Encoding.ASCII.GetBytes(headerStr);
            fileData = screenShot.GetRawTextureData();
        }
        // create new thread to offload the saving from the main thread
        new System.Threading.Thread(() =>
        {
            var file = System.IO.File.Create(filename);
            if (fileHeader != null)
            {
                file.Write(fileHeader, 0, fileHeader.Length);
            }
            file.Write(fileData, 0, fileData.Length);
            file.Close();
            Debug.Log(string.Format("Screenshot Saved {0}, size {1}", filename, fileData.Length));
            isProcessing = false;
        }).Start();
        //Cleanup
        Destroy(renderTexture);
        renderTexture = null;
        screenShot = null;
        cam1.SetActive(false);
        cam2.SetActive(false);
        cam3.SetActive(false);
        cam4.SetActive(false);
        canvas.SetActive(true);

    }

    public void TakeScreenShot()
    {
        if (!isProcessing)
        {
            CaptureScreenshot();
        }
        else
        {
            Debug.Log("Currently Processing");
        }
    }
    public void create360Screenshot()
    {

    }
}
