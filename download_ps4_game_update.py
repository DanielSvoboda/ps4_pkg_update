import sys
import os
import hashlib
import urllib.request
import xml.etree.ElementTree as ET
import json
import hmac
import binascii

urlKey = ""
titleId = ""

def main():
    global urlKey, titleId
    
    if len(sys.argv) < 5 or sys.argv[1] != "-key" or sys.argv[3] != "-title":
        show_help()
        return
    
    urlKey = sys.argv[2]
    titleId = sys.argv[4]

    if len(urlKey) != 64:
        print(f"HMAC_SHA256_Patch_Pkg_URL_Key invalid\nMust contain 64 characters!")
        return

    if len(titleId) != 9:
        print(f"Invalid Title ID", f"Title ID: {titleId} invalid\nMust contain 9 characters!\nCorrect example: CUSA00001")
        return
    
    try:
        xmlUrl = f"http://gs-sec.ww.np.dl.playstation.net/plo/np/{titleId}/{get_hash(titleId)}/{titleId}-ver.xml"
                
        with urllib.request.urlopen(xmlUrl) as response:
            xmlContent = response.read()
        
        xmlDoc = ET.fromstring(xmlContent)
        
        titleNode = xmlDoc.find("./tag/package[@version]")
        if titleNode is None:
            raise Exception("Title node not found in XML.")
        
        title = titleNode.find("paramsfo/title")
        if title is None:
            raise Exception("Title element not found in XML.")
        title_text = title.text if title.text else "N/A"
        
        version = titleNode.get("version", "N/A")
        
        sizeBytes = float(titleNode.get("size", 0))
        sizeMB = sizeBytes / (1024 * 1024)
        
        system_ver = titleNode.get("system_ver", "N/A")
        hexadecimal = f"{int(system_ver):08X}" if system_ver != "N/A" else "N/A"
        system_ver_formatted = f"{hexadecimal[0:2]}.{hexadecimal[2:4]}" if hexadecimal != "N/A" else "N/A"
        
        print(f"Title: {title_text}")
        print(f"Version: {version}")
        print(f"Required Firmware: {system_ver_formatted}")
        print(f"PKG Size: {'{:.2f}'.format(sizeMB / 1024) if sizeMB > 1024 else '{:.2f}'.format(sizeMB)} {'GB' if sizeMB > 1024 else 'MB'}")
        
        manifest_url = titleNode.get("manifest_url", "")
        if not manifest_url:
            raise Exception("Manifest URL not found in XML.")
        
        #print(f"Fetching XML from: {xmlUrl}")
        #print(f"Fetching manifest from: {manifest_url}")
        
        with urllib.request.urlopen(manifest_url) as response:
            manifestContent = response.read().decode('utf-8')
        
        manifestJson = json.loads(manifestContent)
        if "pieces" not in manifestJson:
            raise Exception("Expected JSON format not found in manifest.")
        
        for piece in manifestJson["pieces"]:
            print(piece.get("url", "N/A"))
                
    except Exception as ex:
        print(f"Error loading and parsing XML: {ex}")

def show_help():
    if os.name == 'nt':  # Windows
        print("Usage: download_ps4_game_update_console.exe -key <HMAC_SHA256_Patch_Pkg_URL_Key> -title <TitleId>")
    else:  # Linux
        print("Usage: ./download_ps4_game_update_console -key <HMAC_SHA256_Patch_Pkg_URL_Key> -title <TitleId>")

def get_hash(game_id):
    byte_key = string_to_byte_array(urlKey)
    data_bytes = f"np_{game_id}".encode('utf-8')
    hmac_sha256 = hmac.new(byte_key, data_bytes, hashlib.sha256)
    hash_bytes = hmac_sha256.digest()
    hash_hex = binascii.hexlify(hash_bytes).decode('utf-8')
    return hash_hex

def string_to_byte_array(hex_string):
    return bytes.fromhex(hex_string)

if __name__ == "__main__":
    main()