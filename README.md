# InstagramWrapper
<p>Install using nuget:</p>
https://www.nuget.org/packages/Smile.InstagramWrapper/

<H3>Usage:</H3>
Depending on whether you have AccessToken or not, you have two choices:
  <H4>1- With AccessToken:</H4>
    <p>var instagramService = new InstagramService(accessToken);</p>
    <p>// Do what you want...! For example:</p>
    <p>var followingUsers = instagramService.GetFollowingUsers();</p>

  <H4>2- Without AccessToken:</H4>
    <p>// Currently only WPF platform is supported for grabbing user AccessToken</p>
    <p>var instagramService = new InstagramService();</p>
    <p>instagramService.Authenticate(ownerWPFWindow, yourClientId, yourRedirectUri, yourLoginPermissionScopes);</p>
    <p>// Do what you want...! For example:</p>
    <p>var followingUsers = instagramService.GetFollowingUsers();</p>
    </br>
