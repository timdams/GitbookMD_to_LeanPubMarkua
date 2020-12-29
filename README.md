# Gitbook markdown to Leanpub Markua conversion tool

Small tool to convert your markdown files written for [gitbook](gitbook.com), to [leanpub](https://leanpub.com/) markua markdown. 

Does the following:

* Travels all directories where tool is run and will convert any markdown (.md) files it finds to markua, which basically is markdown with som flavour:
   * All text between the following tags ,``<!---NOBOOKSTART--->`` and ``<!---NOBOOKEND--->``, will be deleted. I use these tags to specify which parts shouldn't be in the leanpub version
   * All the gitbook hints (*danger*, *warning* and *tip*) are converted to leanpub blurbs
   * Removes any html comments (``<!---   --->``) . I use these tags to mark any text in my gitbook markdown that should be ignored by gitbook, but should be part of the leanpub version
   
   
 I've used this tool to create my [C# courses](http://leanpub.com/ziescherp)
