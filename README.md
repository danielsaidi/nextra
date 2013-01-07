NExtra
======

	Author:		Daniel Saidi [daniel.saidi@gmail.com]

NExtra is an open-source library that contains extended functionality
for the .NET Framework. I continously add reusable interfaces/classes
that I develop, that can be reused in projects of all kinds.

If I add code that I found on blogs or other web resources, I include
a link to the original implementation in the source code.


Web resources
-------------

You can find more information about NExtra at the following resources:

	Web site:		http://danielsaidi.github.com/NExtra
	Source code:	http://github.com/danielsaidi/NExtra
	Downloads:		http://github.com/danielsaidi/NExtra/downloads
	Issues:			http://github.com/danielsaidi/NExtra/issues
	Blog:			http://danielsaidi.wordpress.com/category/nextra/
	Documentation:	http://danielsaidi.github.com/nextra/documentation

Do not hesitate to contact me if you have any questions. To report an
issue or a bug, either use the issues page or drop me an e-mail.

Contributions to the library are more than welcome. Just send me pull
requests via GitHub or attach your code in an e-mail. Anything goes :)


Getting started
---------------

You can grab the source code from GitHub or get pre-compiled binaries
either from NuGet or from the download page. If you are new to NExtra,
however, I would advice you to just grab the source code and pick out
the parts that you need instead of fumbling around with compiled code.

If you decide to go with the precompiled DLLs, NExtra consists of the
following projects:

	NExtra
	NExtra.Web
	NExtra.Mvc
	NExtra.Wpf
	NExtra.WebForms
	NExtra.WinForms
	
The NExtra namespace extends System, and can be used in most projects,
provided that it use the required .NET version. The other libs should
only be used in projects that depend on the corresponding System libs.
E.g. only use NExtra.Web in projects that depend on System.Web.


Documentation
-------------

I will extract and publish documentation for the NExtra library every
now and then. This is a manual procedure, so if I haven't updated the
online documentation, just let me know and I'll fix it.


License
-------

NExtra is released under the MIT License, which means that you can do
much anything you want with it. Read more about the MIT license here:

http://www.opensource.org/licenses/mit-license.php

What it means is basically this: If you use NExtra and happen to like
it, please spread the word. Also, do not take credit for other's work.
I add links to all implementations that I use, and assume that you do
the same.

If you take anything out of NExtra, let the author information remain
in the source code.

