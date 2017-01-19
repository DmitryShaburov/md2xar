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
dotnet run <wiki-repository> <out-file> <xwiki-locale>  
3. Import your <out-file> into your XWiki
