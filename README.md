# md2xar
Tool to convert *.md github-like wiki into XWiki XAR file

## Prerequisites
* Installed .NET Core 1.0.3 LTS (works on Windows, Linux, MacOS)
* XWiki with Markdown extension

## Usage
1. Clone your git *.md wiki  
2. Download, build and run tool:  
git clone https://github.com/DmitryShaburov/md2xar.git  
cd md2xar/md2xar  
dotnet restore  
dotnet run */path/to/your/wiki* */path/to/result.xar* *xwiki_LOCALE*   
3. Import your *result.xar* into your XWiki
