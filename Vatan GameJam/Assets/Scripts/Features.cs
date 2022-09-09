using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Features
{
    //LAPTOP
    public static string[] LaptopRAM { get; private set; } = new string[] { "8 GB RAM" , "16 GB RAM", "32 GB RAM", "64 GB RAM" };
    public static string[] RAM { get; private set; } = new string[] { "8 GB RAM", "16 GB RAM", "32 GB RAM", "64 GB RAM", "128 GB RAM" };
    public static string[] LaptopStorageSpace { get; private set; } = new string[] { "256 GB Storage Space", "512 GB Storage Space", "1024 GB Storage Space", "2056 GB Storage Space" };
    public static string[] LaptopGraphicsCard { get; private set; } = new string[] { "1650 Graphics Card", "1650ti Graphics Card", "3050 Graphics Card", "3050ti Graphics Card", "3060 Graphics Card", "3070 Graphics Card", "3080 Graphics Card" };
    public static string[] LaptopProcessor { get; private set; } = new string[] { "3600 Processor", "3700 Processor", "5600 Processor", "5700 Processor", "5800 Processor", "5900 Processor" };
    //VACUUM CLEANER
    public static string[] DirtCapacity { get; private set; } = new string[] { "0.31 L Dirt Capacity", "0.41 L Dirt Capacity", "0.51 L Dirt Capacity", "0.61 L Dirt Capacity" };
    public static string[] VacuumCleanerWeight { get; private set; } = new string[] { "1.2 kg weight", "2.4 kg weight", "3.6 kg weight" };
    public static string[] SuctionPower { get; private set; } = new string[] { "250 W Suction Power", "300 W Suction Power", "350 W Suction Power", "400 W Suction Power", "450 W Suction Power" };
    //MONITOR
    public static string[] MonitorScreenSize { get; private set; } = new string[] { "24.5\" Screen Size" , "27\" Screen Size" , "32\" Screen Size" };
    public static string[] ScreenResolution { get; private set; } = new string[] { "1920X1080 Resolution", "2560X1440 Resolution", "3840X2160 Resolution" };
    public static string[] MonitorRefreshRate { get; private set; } = new string[] { "120Hz Refresh Rate", "144Hz Refresh Rate", "165Hz Refresh Rate", "240Hz Refresh Rate" };
    //TV
    public static string[] TVScreenSize { get; private set; } = new string[] { "32\" Screen Size", "43\" Screen Size", "50\" Screen Size", "65\" Screen Size" };
    public static string[] SatelliteReceiver { get; private set; } = new string[] { "one Satellite Receiver", "No Receiver available" };
    //KEYBOARD
    public static string[] Switch { get; private set; } = new string[] { "Red Switch", "Brown Switch", "Blue Switch", "Non-Mechanical Keys" }; 
    public static string[] KeyboardWeight { get; private set; } = new string[] { "0.6 kg weight", "0.8 kg weight", "1 kg weight", "1.2 kg weight" }; 
    public static string[] BackLit { get; private set; } = new string[] { "No Backlit keys available", "Backlit keys" };
    //CELLPHONE
    public static string[] CellPhoneStorageSpace { get; private set; } = new string[] { "64 GB Storage Space", "128 GB Storage Space", "256 GB Storage Space" };
    public static string[] CellPhoneMemory { get; private set; } = new string[] { "4 GB Memory", "6 GB Memory", "8 GB Memory", "10 GB Memory" };
    public static string[] CellPhoneWeight { get; private set; } = new string[] { "196 gr weight", "216 gr weight", "230 gr weight", "270 gr weight", "312 gr weight" };
    //HEADPHONE
    public static string[] HeadPhoneWeight { get; private set; } = new string[] { "153 gr weight", "180 gr weight", "255 gr weight", "353 gr weight" };
    public static string[] ConnectionType { get; private set; } = new string[] { "Wireless Connection", "Wired Connection", "Bluetooth Connection" };
    public static string[] Microphone { get; private set; } = new string[] { "one Microphone", "No Microphone available" };
    //MOUSE
    public static string[] NumberOfMouseButtons { get; private set; } = new string[] { "3 Buttons", "4 Buttons", "5 Buttons", "6 Buttons" };
    public static string[] MouseWeight { get; private set; } = new string[] { "57 gr weight", "65 gr weight", "85 gr weight", "126 gr weight", "215 gr weight" };
    //PRINTER
    public static string[] PrinterSpeed { get; private set; } = new string[] { "22 ppm Speed", "30 ppm Speed" , "36 ppm Speed" , "40 ppm Speed" };
    public static string[] PrinterWeight { get; private set; } = new string[] { "3.6 kg weight", "4.1 kg weight", "5.7 kg weight", "6.3 kg weight" };
    public static string[] PrinterResolution { get; private set; } = new string[] { "250 dpi Resolution", "300 dpi Resolution", "400 dpi Resolution", "500 dpi Resolution", "750 dpi Resolution", "1200 dpi Resolution" };
    //DEBUG
    public static string[] DebugMessages { get; private set; } = new string[] { "<color=\"red\"><size=70%><b><ERROR - Unknown product.></b><color=\"black\"><size=100%>" };
}