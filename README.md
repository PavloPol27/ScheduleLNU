# LNU-scheduler
 
[Requirements](https://docs.google.com/document/d/1DWLT_u7qI13H4BJcrbURAkuEblVvUH_MWA6TkRZpCcI/edit?usp=sharing)


[Reports](http://agile.tests-ua.com/Projects/368/Sprints)


Sprint with auth:
 1. Include Identity 
     * Update database
     * Replace id with token
 2. Login
     * View
     * Back-end
 3. Register
     * View
     * Back-end
 4. Restore password
     * View
     * Back-end
 5. Email sender service

To add cookies use in controll *HttpContext* propertie and use extension method SignInAsync(). It takes list of tupples of objects. 
```c#
 await HttpContext.SignInAsync((nameof(studentId), studentId));
```

Also you can add more claims for example:
```c#
 await HttpContext.SignInAsync((nameof(studentId), studentId), 
                              (ClaimsIdentity.DefaultNameClaimType, "name"));
```
