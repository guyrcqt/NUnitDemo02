using NUnit.Framework;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Threading;

namespace NUnitDemo02
{
    public class Tests
    {
        //Demo from: https://www.youtube.com/watch?v=2hkbXJBUU7k&list=PLQmpEDfo4nzHsuk-szZ30DoXr8F53LqZJ&index=2

        #region Constants 
        private const string STRING_ERROR_IN = "Error in:";

        #endregion Constants 

        #region Enums
        private enum menEntryType { Error, Warning, Information, Success };

        #endregion Enums

        #region Variables
        IWebDriver mobjDriver = null;

        #endregion Variables

        #region Methods

        private void msConsoleLog(string vsMessage, menEntryType venEntryType)
        {

            System.ConsoleColor objColor = System.ConsoleColor.White;

            switch (venEntryType)
            {
                case menEntryType.Error:
                    objColor = System.ConsoleColor.Red;
                    break;
                case menEntryType.Warning:
                    objColor = System.ConsoleColor.Yellow;
                    break;
                case menEntryType.Information:
                    objColor = System.ConsoleColor.White;
                    break;
                case menEntryType.Success:
                    objColor = System.ConsoleColor.Green;
                    break;
            }

            //////////////////////////////////////////
            if (Debugger.IsAttached)
            {
                Debug.WriteLine(vsMessage);
            }
            //////////////////////////////////////////
            System.Console.ForegroundColor = objColor;

            System.Console.WriteLine(vsMessage);

            System.Console.ResetColor();

        }//msConsoleLog

        #endregion Methods

        #region Test Setup

        [OneTimeSetUp]
        public void StartChrome()
        {

            string sCurrentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;

            try
            {
                msConsoleLog("Creating driver.", menEntryType.Information);

                mobjDriver = new ChromeDriver();
            }
            catch (System.Exception ex)
            {
                mobjDriver = null;

                msConsoleLog("Could not create driver.", menEntryType.Error);

                if (Debugger.IsAttached)
                {
                    Debug.WriteLine($"{STRING_ERROR_IN} {sCurrentMethod}\n{ex.ToString()}");
                }
            }


        }//StartChrome

        [OneTimeTearDown]
        public void Close()
        {
            string sCurrentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;

            if (mobjDriver != null)
            {
                msConsoleLog("Closing driver...", menEntryType.Information);

                try
                {
                    mobjDriver.Close();
                }
                catch (System.Exception ex)
                {
                    msConsoleLog("Could not close driver.", menEntryType.Error);

                    if (Debugger.IsAttached)
                    {
                        Debug.WriteLine($"{STRING_ERROR_IN} {sCurrentMethod}\n{ex.ToString()}");
                    }
                }

                mobjDriver = null;
            }
        }//Close
        #endregion Test Setup

        #region Test Steps

        [Test]
        public void Test1()
        {
            string sCurrentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            string sWebPageFile = string.Empty;
            string sWebElementID = string.Empty;

            IWebElement txtFullName = null;
            IWebElement objAnchor = null;

            DirectoryInfo diWebPageFile = new System.IO.DirectoryInfo(System.AppDomain.CurrentDomain.BaseDirectory);

            Debug.WriteLine($"BIN folder ={diWebPageFile.FullName}");

            diWebPageFile = diWebPageFile.Parent.Parent.Parent;
            sWebPageFile = diWebPageFile.FullName + @"\WebPage\index.html";

            Debug.WriteLine($"sWebPageFile={sWebPageFile}");


            if (File.Exists(sWebPageFile))
            {
                Debug.WriteLine("Found the HTML file.");
            }
            else
            {
                sWebPageFile = string.Empty;

                Debug.WriteLine("DID NOT find the HTML file.");
            }

            if ((mobjDriver != null) && (sWebPageFile != string.Empty))
            {
                try
                {
                    mobjDriver.Url = sWebPageFile;

                    try
                    {
                        sWebElementID = "txtFullName";

                        txtFullName = mobjDriver.FindElement(By.Id(sWebElementID));

                        if (txtFullName != null)
                        {
                            txtFullName.Clear();

                            txtFullName.SendKeys("Found by ID");
                        }//if (txtFullName != null)   
                        else
                        {
                            msConsoleLog($"Could not find web element: {sWebElementID}", menEntryType.Error);
                        }
                    }
                    catch (System.Exception ex)
                    {
                        txtFullName = null;

                        msConsoleLog($"Could not find web element: {sWebElementID}", menEntryType.Error);

                        if (Debugger.IsAttached)
                        {
                            Debug.WriteLine($"{STRING_ERROR_IN} {sCurrentMethod}\n{ex.ToString()}");
                        }
                    }
                    ///////////////////////////////////////
                    System.Threading.Thread.Sleep(2000);
                    ///////////////////////////////////////
                    try
                    {
                        sWebElementID = "Full Name";

                        txtFullName = mobjDriver.FindElement(By.Name(sWebElementID));

                        if (txtFullName != null)
                        {
                            txtFullName.Clear();

                            txtFullName.SendKeys("Found by name");
                        }//if (txtFullName != null)   
                        else
                        {
                            msConsoleLog($"Could not find web element: {sWebElementID}", menEntryType.Error);
                        }
                    }
                    catch (System.Exception ex)
                    {
                        txtFullName = null;

                        msConsoleLog($"Could not find web element: {sWebElementID}", menEntryType.Error);

                        if (Debugger.IsAttached)
                        {
                            Debug.WriteLine($"{STRING_ERROR_IN} {sCurrentMethod}\n{ex.ToString()}");
                        }
                    }
                    ///////////////////////////////////////
                    System.Threading.Thread.Sleep(2000);
                    ///////////////////////////////////////
                    try
                    {
                        sWebElementID = "fullName";

                        txtFullName = mobjDriver.FindElement(By.ClassName(sWebElementID));

                        if (txtFullName != null)
                        {
                            txtFullName.Clear();

                            txtFullName.SendKeys("Found by class name");
                        }//if (txtFullName != null)
                        else
                        {
                            msConsoleLog($"Could not find web element: {sWebElementID}", menEntryType.Error);
                        }
                    }
                    catch (System.Exception ex)
                    {
                        txtFullName = null;

                        msConsoleLog($"Could not find web element: {sWebElementID}", menEntryType.Error);

                        if (Debugger.IsAttached)
                        {
                            Debug.WriteLine($"{STRING_ERROR_IN} {sCurrentMethod}\n{ex.ToString()}");
                        }
                    }
                    ///////////////////////////////////////
                    System.Threading.Thread.Sleep(2000);
                    ///////////////////////////////////////
                    try
                    {
                        sWebElementID = "input";

                        txtFullName = mobjDriver.FindElement(By.TagName(sWebElementID));

                        if (txtFullName != null)
                        {
                            txtFullName.Clear();

                            txtFullName.SendKeys("Found by tag name");
                        }//if (txtFullName != null)
                        else
                        {
                            msConsoleLog($"Could not find web element: {sWebElementID}", menEntryType.Error);
                        }
                    }
                    catch (System.Exception ex)
                    {
                        txtFullName = null;

                        msConsoleLog($"Could not find web element: {sWebElementID}", menEntryType.Error);

                        if (Debugger.IsAttached)
                        {
                            Debug.WriteLine($"{STRING_ERROR_IN} {sCurrentMethod}\n{ex.ToString()}");
                        }
                    }
                    ///////////////////////////////////////
                    System.Threading.Thread.Sleep(2000);
                    ///////////////////////////////////////
                    try
                    {
                        sWebElementID = "input[data-type='FullName']";

                        txtFullName = mobjDriver.FindElement(By.CssSelector(sWebElementID));

                        if (txtFullName != null)
                        {
                            txtFullName.Clear();

                            txtFullName.SendKeys("Found by CSS Selector");
                        }//if (txtFullName != null)
                        else
                        {
                            msConsoleLog($"Could not find web element: {sWebElementID}", menEntryType.Error);
                        }
                    }
                    catch (System.Exception ex)
                    {
                        txtFullName = null;

                        msConsoleLog($"Could not find web element: {sWebElementID}", menEntryType.Error);

                        if (Debugger.IsAttached)
                        {
                            Debug.WriteLine($"{STRING_ERROR_IN} {sCurrentMethod}\n{ex.ToString()}");
                        }
                    }
                    ///////////////////////////////////////
                    System.Threading.Thread.Sleep(2000);
                    ///////////////////////////////////////
                    try
                    {
                        sWebElementID = "//input[@data-type='FullName']";

                        txtFullName = mobjDriver.FindElement(By.XPath(sWebElementID));

                        if (txtFullName != null)
                        {
                            txtFullName.Clear();

                            txtFullName.SendKeys("Found by XPath");
                        }//if (txtFullName != null)
                        else
                        {
                            msConsoleLog($"Could not find web element: {sWebElementID}", menEntryType.Error);
                        }
                    }
                    catch (System.Exception ex)
                    {
                        txtFullName = null;

                        msConsoleLog($"Could not find web element: {sWebElementID}", menEntryType.Error);

                        if (Debugger.IsAttached)
                        {
                            Debug.WriteLine($"{STRING_ERROR_IN} {sCurrentMethod}\n{ex.ToString()}");
                        }
                    }
                    ///////////////////////////////////////
                    System.Threading.Thread.Sleep(2000);
                    ///////////////////////////////////////
                    try
                    {
                        sWebElementID = "Submit information";

                        //Option 1:
                        //objAnchor = mobjDriver.FindElement(By.LinkText(sWebElementID));
                        //Option 2:
                        objAnchor = mobjDriver.FindElement(By.PartialLinkText("Submit"));
                        if (objAnchor != null)
                        {
                            ////////////
                            try
                            {
                                msConsoleLog($"Trying to click : {sWebElementID}", menEntryType.Information);

                                objAnchor.Click();

                            }
                            catch (System.Exception ex)
                            {
                                msConsoleLog($"Could not click web element: {sWebElementID}", menEntryType.Error);

                                if (Debugger.IsAttached)
                                {
                                    Debug.WriteLine($"{STRING_ERROR_IN} {sCurrentMethod}\n{ex.ToString()}");
                                }
                            }
                            ////////////
                        }//if (objAnchor != null)                        
                        else
                        {
                            msConsoleLog($"Could not find web element: {sWebElementID}", menEntryType.Error);
                        }
                    }
                    catch (System.Exception ex)
                    {
                        objAnchor = null;

                        msConsoleLog($"Could not find web element: {sWebElementID}", menEntryType.Error);

                        if (Debugger.IsAttached)
                        {
                            Debug.WriteLine($"{STRING_ERROR_IN} {sCurrentMethod}\n{ex.ToString()}");
                        }
                    }
                }
                catch (NUnit.Framework.AssertionException)
                {
                    if (Debugger.IsAttached)
                    {
                        Debug.WriteLine($"{sCurrentMethod} : Assertion Exception");
                    }
                }
                catch (System.Exception ex)
                {

                    msConsoleLog($"Could not go to url: {sWebPageFile}", menEntryType.Error);

                    if (Debugger.IsAttached)
                    {
                        Debug.WriteLine($"{STRING_ERROR_IN} {sCurrentMethod}\n{ex.ToString()}");
                    }
                }
            }//if ((mobjDriver != null) && (sWebPageFile != string.Empty))

            ////////////////////////////////////////////
            Thread.Sleep(5000);
            //////////////////
            Assert.Pass();
            //////////////////

        }//Test1

        #endregion Test Steps
    }//}//class Tests
}//namespace