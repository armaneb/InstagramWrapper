# InstagramWrapper
<p>Install using nuget:</p>
https://www.nuget.org/packages/Smile.InstagramWrapper/

<H3>Usage:</H3>
Depending on whether you have AccessToken or not, you have two choices:
  <H4>1- With AccessToken:</H4>
  <pre>
  <code>
    var instagramService = new InstagramService(accessToken);
    // Do what you want...! For example:
    var followingUsers = instagramService.GetFollowingUsers();
  </code>
  </pre>
  <H4>2- Without AccessToken:</H4>
  <pre>
  <code>
    // Currently only WPF platform is supported for grabbing user AccessToken
    var instagramService = new InstagramService();
    instagramService.Authenticate(ownerWPFWindow, yourClientId, yourRedirectUri, yourLoginPermissionScopes);
    // Do what you want...! For example:
    var followingUsers = instagramService.GetFollowingUsers();
  </code>
  </pre>
