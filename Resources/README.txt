NExtra
======

	Author:		Daniel Saidi [daniel.saidi@gmail.com]

NExtra is an open-source library that contains extended functionality
for the .NET Framework. I continously add things that I create in the
various projects I work with, if I find that they are relevant enough
for others and general enough to be reusable in other projects.

If I add stuff that I find on a blog or other web resources, I include
a link to the original implementation in the source code.


Web resources
-------------

You can find more information about NExtra at the following resources:

	Web site:		http://danielsaidi.github.com/NExtra
	Source code:	http://github.com/danielsaidi/NExtra
	Downloads:		http://github.com/danielsaidi/NExtra/tags
	Issues:			http://github.com/danielsaidi/NExtra/issues
	Blog:			http://danielsaidi.wordpress.com/category/nextra
	
Do not hesitate to contact me if you have any questions that you need
to ask, any bugs or issues that you need help with, or if you want to
give me feedback, suggestions etc. Bugs can easily be reported, using
the issue page.

Contributions to NExtra are more than welcome. If you build something
that you wish to share, fix a bug, improve a unit test etc. just send
me a pull request requests via GitHub or simply attach your code in a
regular e-mail.


Getting started
---------------

You can grab the source code directly from GitHub, download a certain
version of the source code from the download page or get pre-compiled
binaries directly from within Visual Studio, using NuGet.

If you are new to NExtra, I would definitively advice you to grab the
latest source code, browse through it and pick out the parts you need,
instead of starting out with the compiled DLLs.

NExtra consists of the following projects:

	NExtra
	NExtra.Web
	NExtra.Mvc
	NExtra.Wpf
	NExtra.WebForms
	NExtra.WinForms
	
The NExtra namespace extends System, and can be used in most projects.
The other projects depend on the corresponding System libraries. This
means that NExtra.Web requires System.Web etc.


Documentation
-------------

From version 3.0, I have decided to not extract any documentation for
NExtra. I believe that it is easier to grab the source code and check
it out, or even browse through the code on GitHub, than it is to plow
through page after page within a generated HTML structure.

Let me know if you think that I am wrong. Extracting documentation is
a piece of cake, so if you need it, it is easily done.


License
-------

NExtra is released under the MIT License, which means that you can do
much anything you want with it. Read more about the MIT license here:

http://www.opensource.org/licenses/mit-license.php

What it means is basically this: If you use NExtra and happen to like
it, please spread the word. Also, do not take credit for other's work.
If you take anything out of NExtra, let the author information remain
in the source code.

