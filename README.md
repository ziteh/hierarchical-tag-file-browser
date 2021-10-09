# Hierarchical Tag File Browser
[![License: MIT](https://img.shields.io/badge/license-MIT-brightgreen.svg)](https://github.com/ziteh/hierarchical-tag-file-browser/blob/main/LICENSE)  
A simple hierarchical tagging file browser.   
一個簡單的階層式標籤檔案瀏覽器。

> You use tags to organize files and folders, why not organize tags by tags too?  
> --This is why you need Hierarchical-Tags.

![fig](https://i.imgur.com/8SxXHNl.png)

# XML-Based
## Tag Database

```xml
<?xml version="1.0" encoding="UTF-8"?>
<root>
  <tag name="Example" />
  <tag name="Personal" />
  <tag name="Starred" />
  <tag name="Projects">
    <type>tagSet</type>
  </tag>
  <tag name="Blog">
    <parentTag>Projects</parentTag>
    <parentTag>Personal</parentTag>
  </tag>
  <tag name="APP">
    <parentTag>Projects</parentTag>
  </tag>
</root>
<!--
You can get:

root
 ├──Example
 ├──Personal
 │   └──Blog
 ├──Starred
 └──[Projects]
     ├──Blog
     └──APP
-->
```

# Demo
1. Open `TagBaseFileBrowser.sln` with Visual Studio.
2. Copy [`config.json`](/Test/config.json) from [`Test`](/Test) to execution directory (e.g. `\hierarchical-tag-file-browser\TagBaseFileBrowser\bin\Debug\`).
3. Press "Start" button (or press <kbd>F5</kbd>) in Visual Studio to build and run "TagBaseFileBrowser".
4. If you get something wrong, may need to edit the paths of `defaultPath` and `TestFolder` in [`config.json`](/Test/config.json) and [`parameters.xml`](/Test/parameters.xml) (e.g. `\hierarchical-tag-file-browser\Test\`).
