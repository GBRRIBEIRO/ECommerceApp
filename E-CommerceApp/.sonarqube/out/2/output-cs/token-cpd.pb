�+
]C:\Dev\Projects\.NET Work\E-CommerceApp\E-Commerce.Services\Extensions\AuthenticationSetup.cs
	namespace 	

E_Commerce
 
. 
Services 
. 
Services &
{ 
public 

static 
class 
AuthenticationSetup +
{ 
public 
static 
void 
AddAuthentication ,
(, -
this- 1
IServiceCollection2 D
servicesE M
,M N
IConfigurationO ]
configuration^ k
)k l
{ 	
var !
jwtAppSettingsOptions %
=& '
configuration( 5
.5 6

GetSection6 @
(@ A
nameofA G
(G H

JwtOptionsH R
)R S
)S T
;T U
var 
securityKey 
= 
new ! 
SymmetricSecurityKey" 6
(6 7
Encoding7 ?
.? @
ASCII@ E
.E F
GetBytesF N
(N O
configurationO \
.\ ]

GetSection] g
(g h
$str	h �
)
� �
.
� �
Value
� �
)
� �
)
� �
;
� �
services 
. 
	Configure 
< 

JwtOptions )
>) *
(* +
options+ 2
=>3 5
{ 
options 
. 
Issuer 
=  !
jwtAppSettingsOptions! 6
[6 7
nameof7 =
(= >

JwtOptions> H
.H I
IssuerI O
)O P
]P Q
;Q R
options 
. 
Audience  
=! "!
jwtAppSettingsOptions# 8
[8 9
nameof9 ?
(? @

JwtOptions@ J
.J K
AudienceK S
)S T
]T U
;U V
options 
. 
SigningCredentials *
=+ ,
new- 0
SigningCredentials1 C
(C D
securityKeyD O
,O P
SecurityAlgorithmsQ c
.c d

HmacSha512d n
)n o
;o p
options 
. !
AccessTokenExpiration -
=. /
int0 3
.3 4
Parse4 9
(9 :!
jwtAppSettingsOptions: O
[O P
nameofP V
(V W

JwtOptionsW a
.a b!
AccessTokenExpirationb w
)w x
]x y
??z |
$str	} �
)
� �
;
� �
options 
. "
RefreshTokenExpiration .
=/ 0
int1 4
.4 5
Parse5 :
(: ;!
jwtAppSettingsOptions; P
[P Q
nameofQ W
(W X

JwtOptionsX b
.b c"
RefreshTokenExpirationc y
)y z
]z {
??| ~
$str	 �
)
� �
;
� �
} 
) 
; 
var!! 
tokenValidation!! 
=!!  !
new!!" %%
TokenValidationParameters!!& ?
{"" 
ValidateIssuer## 
=##  
true##! %
,##% &
ValidIssuer$$ 
=$$ 
configuration$$ +
.$$+ ,

GetSection$$, 6
($$6 7
$str$$7 J
)$$J K
.$$K L
Value$$L Q
,$$Q R
ValidateAudience%%  
=%%! "
true%%# '
,%%' (
ValidAudience&& 
=&& 
configuration&&  -
.&&- .

GetSection&&. 8
(&&8 9
$str&&9 N
)&&N O
.&&O P
Value&&P U
,&&U V$
ValidateIssuerSigningKey'' (
='') *
true''+ /
,''/ 0
IssuerSigningKey((  
=((! "
securityKey((# .
,((. /!
RequireExpirationTime)) %
=))& '
true))( ,
,)), -
ValidateLifetime**  
=**! "
true**# '
,**' (
	ClockSkew++ 
=++ 
TimeSpan++ $
.++$ %
Zero++% )
,++) *
},, 
;,, 
services.. 
... 
AddAuthentication.. &
(..& '
options..' .
=>../ 1
{// 
options00 
.00 %
DefaultAuthenticateScheme00 1
=002 3
JwtBearerDefaults004 E
.00E F 
AuthenticationScheme00F Z
;00Z [
options11 
.11 "
DefaultChallengeScheme11 .
=11/ 0
JwtBearerDefaults111 B
.11B C 
AuthenticationScheme11C W
;11W X
}22 
)22 
.22 
AddJwtBearer22 
(22 
options22 #
=>22$ &
options33 
.33 %
TokenValidationParameters33 1
=332 3
tokenValidation334 C
)44 
;44 
}55 	
public77 
static77 
void77 $
AddAuthorizationPolicies77 3
(773 4
this774 8
IServiceCollection779 K
services77L T
)77T U
{88 	
services99 
.99 
AddSingleton99 !
<99! "!
IAuthorizationHandler99" 7
>997 8
(998 9
)999 :
;99: ;
}:: 	
};; 
}<< �	
aC:\Dev\Projects\.NET Work\E-CommerceApp\E-Commerce.Services\Services\Configurations\JwtOptions.cs
	namespace 	

E_Commerce
 
. 
Services 
. 
Services &
.& '
Configurations' 5
{		 
public

 

class

 

JwtOptions

 
{ 
public 
string 
Issuer 
{ 
get "
;" #
set$ '
;' (
}) *
public 
string 
Audience 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
SigningCredentials !
SigningCredentials" 4
{5 6
get7 :
;: ;
set< ?
;? @
}A B
public 
int !
AccessTokenExpiration (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
public 
int "
RefreshTokenExpiration )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
} 
} ��
gC:\Dev\Projects\.NET Work\E-CommerceApp\E-Commerce.Services\Services\Implementations\IdentityService.cs
	namespace 	

E_Commerce
 
. 
Services 
. 
Services &
.& '
Implementations' 6
{ 
public 

class 
IdentityService  
:! "
IIdentityService# 3
{ 
private 
UserManager 
< 
	ECommUser %
>% &
UserManager' 2
{3 4
get5 8
;8 9
}: ;
public 

JwtOptions 
_jwtOptions %
{& '
get( +
;+ ,
}- .
private 
IUnitOfWork 
_unitOfWork '
;' (
public 
SignInManager 
< 
	ECommUser &
>& '
SignInManager( 5
{6 7
get8 ;
;; <
}= >
public 
IdentityService 
( 
SignInManager ,
<, -
	ECommUser- 6
>6 7
signInManager8 E
,E F
UserManagerG R
<R S
	ECommUserS \
>\ ]
userManager^ i
,i j
IOptionsk s
<s t

JwtOptionst ~
>~ 

jwtOptions
� �
,
� �
IUnitOfWork
� �

unitOfWork
� �
)
� �
{ 	
SignInManager 
= 
signInManager )
;) *
UserManager 
= 
userManager %
;% &
_jwtOptions 
= 

jwtOptions $
.$ %
Value% *
;* +
_unitOfWork 
= 

unitOfWork $
;$ %
} 	
public!! 
async!! 
Task!! 
<!! 
RegisterResponse!! *
>!!* +
RegisterUser!!, 8
(!!8 9
RegisterRequest!!9 H
request!!I P
)!!P Q
{"" 	
var## 
identityUser## 
=## 
new## "
	ECommUser### ,
{$$ 
	FirstName%% 
=%% 
request%% #
.%%# $
	FirstName%%$ -
,%%- .
LastName&& 
=&& 
request&& "
.&&" #
LastName&&# +
,&&+ ,
Email'' 
='' 
request'' 
.''  
Email''  %
,''% &
UserName(( 
=(( 
request(( "
.((" #
Email((# (
,((( )
EmailConfirmed)) 
=))  
true))! %
,))% &
PhoneNumber** 
=** 
request** %
.**% &
PhoneNumber**& 1
,**1 2 
PhoneNumberConfirmed++ $
=++% &
true++' +
,+++ ,
},, 
;,, 
var// 
result// 
=// 
await// 
UserManager// *
.//* +
CreateAsync//+ 6
(//6 7
identityUser//7 C
,//C D
request//E L
.//L M
Password//M U
)//U V
;//V W
if00 
(00 
result00 
.00 
	Succeeded00  
)00  !
{11 
await22 
UserManager22 !
.22! ""
SetLockoutEnabledAsync22" 8
(228 9
identityUser229 E
,22E F
false22G L
)22L M
;22M N
}33 
var55 
userResponse55 
=55 
new55 "
RegisterResponse55# 3
(553 4
success554 ;
:55; <
true55= A
)55A B
;55B C
if66 
(66 
!66 
result66 
.66 
	Succeeded66 !
&&66" $
result66% +
.66+ ,
Errors66, 2
.662 3
Count663 8
(668 9
)669 :
>66; <
$num66= >
)66> ?
{77 
userResponse88 
.88 
	AddErrors88 &
(88& '
result88' -
.88- .
Errors88. 4
.884 5
Select885 ;
(88; <
err88< ?
=>88@ B
err88C F
.88F G
Description88G R
)88R S
)88S T
;88T U
}99 
return:: 
userResponse:: 
;::  
};; 	
public>> 
async>> 
Task>> 
<>> 
LoginResponse>> '
>>>' (
	LoginUser>>) 2
(>>2 3
LoginRequest>>3 ?
request>>@ G
)>>G H
{?? 	
varAA 
resultAA 
=AA 
awaitAA 
SignInManagerAA ,
.AA, -
PasswordSignInAsyncAA- @
(AA@ A
requestAAA H
.AAH I
EmailAAI N
,AAN O
requestAAP W
.AAW X
PasswordAAX `
,AA` a
falseAAb g
,AAg h
falseAAi n
)AAn o
;AAo p
ifDD 
(DD 
!DD 
resultDD 
.DD 
	SucceededDD !
)DD! "
{EE 
varFF 
respFF 
=FF 
newFF 
LoginResponseFF ,
(FF, -
)FF- .
;FF. /
respGG 
.GG 
AddErrorGG 
(GG 
$strGG >
)GG> ?
;GG? @
returnHH 
respHH 
;HH 
}II 
returnLL 
awaitLL 
GetUserCredentialsLL +
(LL+ ,
requestLL, 3
.LL3 4
EmailLL4 9
)LL9 :
;LL: ;
}NN 	
publicQQ 
asyncQQ 
TaskQQ 
<QQ 
LoginResponseQQ '
>QQ' ( 
LoginWithoutPasswordQQ) =
(QQ= >
stringQQ> D
	userEmailQQE N
)QQN O
{RR 	
varTT 
userLoginResponseTT !
=TT" #
newTT$ '
LoginResponseTT( 5
(TT5 6
)TT6 7
;TT7 8
varWW 
userWW 
=WW 
awaitWW 
UserManagerWW (
.WW( )
FindByEmailAsyncWW) 9
(WW9 :
	userEmailWW: C
)WWC D
;WWD E
ifZZ 
(ZZ 
awaitZZ 
UserManagerZZ  
.ZZ  !
IsLockedOutAsyncZZ! 1
(ZZ1 2
userZZ2 6
)ZZ6 7
)ZZ7 8
userLoginResponse[[ !
.[[! "
AddError[[" *
([[* +
$str[[+ =
)[[= >
;[[> ?
else\\ 
if\\ 
(\\ 
!\\ 
await\\ 
UserManager\\ '
.\\' (!
IsEmailConfirmedAsync\\( =
(\\= >
user\\> B
)\\B C
)\\C D
userLoginResponse]] !
.]]! "
AddError]]" *
(]]* +
$str]]+ A
)]]A B
;]]B C
if`` 
(`` 
userLoginResponse`` !
.``! "
Success``" )
)``) *
returnaa 
awaitaa 
GetUserCredentialsaa /
(aa/ 0
useraa0 4
.aa4 5
Emailaa5 :
)aa: ;
;aa; <
returndd 
userLoginResponsedd $
;dd$ %
}ee 	
privategg 
stringgg 
GenerateTokengg $
(gg$ %
IEnumerablegg% 0
<gg0 1
Claimgg1 6
>gg6 7
claimsgg8 >
,gg> ?
DateTimegg@ H
expirationDateggI W
)ggW X
{hh 	
varii 
jwtii 
=ii 
newii 
JwtSecurityTokenii *
(jj 
issuerkk 
:kk 
_jwtOptionskk '
.kk' (
Issuerkk( .
,kk. /
audiencell 
:ll 
_jwtOptionsll )
.ll) *
Audiencell* 2
,ll2 3
claimsmm 
:mm 
claimsmm "
,mm" #
	notBeforenn 
:nn 
DateTimenn '
.nn' (
Nownn( +
,nn+ ,
expiresoo 
:oo 
expirationDateoo +
,oo+ ,
signingCredentialspp &
:pp& '
_jwtOptionspp( 3
.pp3 4
SigningCredentialspp4 F
)qq 
;qq 
returnss 
newss #
JwtSecurityTokenHandlerss .
(ss. /
)ss/ 0
.ss0 1

WriteTokenss1 ;
(ss; <
jwtss< ?
)ss? @
;ss@ A
}tt 	
privateyy 
asyncyy 
Taskyy 
<yy 
LoginResponseyy (
>yy( )
GetUserCredentialsyy* <
(yy< =
stringyy= C
emailyyD I
)yyI J
{zz 	
var|| 
user|| 
=|| 
await|| 
UserManager|| (
.||( )
FindByEmailAsync||) 9
(||9 :
email||: ?
)||? @
;||@ A
var
�� 
accessTokenClaims
�� !
=
��" #
await
��$ )
ObtainClaims
��* 6
(
��6 7
user
��7 ;
,
��; <
isAccessToken
��= J
:
��J K
true
��L P
)
��P Q
;
��Q R
var
��  
refreshTokenClaims
�� "
=
��# $
await
��% *
ObtainClaims
��+ 7
(
��7 8
user
��8 <
,
��< =
isAccessToken
��> K
:
��K L
false
��M R
)
��R S
;
��S T
var
�� '
accessTokenExpirationDate
�� )
=
��* +
DateTime
��, 4
.
��4 5
Now
��5 8
.
��8 9

AddSeconds
��9 C
(
��C D
_jwtOptions
��D O
.
��O P#
AccessTokenExpiration
��P e
)
��e f
;
��f g
var
�� (
refreshTokenExpirationDate
�� *
=
��+ ,
DateTime
��- 5
.
��5 6
Now
��6 9
.
��9 :

AddSeconds
��: D
(
��D E
_jwtOptions
��E P
.
��P Q$
RefreshTokenExpiration
��Q g
)
��g h
;
��h i
var
�� 
refreshToken
�� 
=
�� 
GenerateToken
�� ,
(
��, - 
refreshTokenClaims
��- ?
,
��? @(
refreshTokenExpirationDate
��A [
)
��[ \
;
��\ ]
var
�� 
accessToken
�� 
=
�� 
GenerateToken
�� +
(
��+ ,
accessTokenClaims
��, =
,
��= >'
accessTokenExpirationDate
��? X
)
��X Y
;
��Y Z
return
�� 
new
�� 
LoginResponse
�� $
(
�� 
success
�� 
:
�� 
true
�� 
,
�� 
accessToken
�� 
:
�� 
accessToken
�� (
,
��( )
refreshToken
�� 
:
�� 
refreshToken
�� *
)
�� 
;
�� 
}
�� 	
private
�� 
async
�� 
Task
�� 
<
�� 
IList
��  
<
��  !
Claim
��! &
>
��& '
>
��' (
ObtainClaims
��) 5
(
��5 6
	ECommUser
��6 ?
user
��@ D
,
��D E
bool
��F J
isAccessToken
��K X
)
��X Y
{
�� 	
var
�� 
claims
�� 
=
�� 
new
�� 
List
�� !
<
��! "
Claim
��" '
>
��' (
(
��( )
)
��) *
;
��* +
claims
�� 
.
�� 
Add
�� 
(
�� 
new
�� 
Claim
��  
(
��  !%
JwtRegisteredClaimNames
��! 8
.
��8 9
Sub
��9 <
,
��< =
user
��> B
.
��B C
Id
��C E
)
��E F
)
��F G
;
��G H
claims
�� 
.
�� 
Add
�� 
(
�� 
new
�� 
Claim
��  
(
��  !%
JwtRegisteredClaimNames
��! 8
.
��8 9
Email
��9 >
,
��> ?
user
��@ D
.
��D E
Email
��E J
)
��J K
)
��K L
;
��L M
claims
�� 
.
�� 
Add
�� 
(
�� 
new
�� 
Claim
��  
(
��  !%
JwtRegisteredClaimNames
��! 8
.
��8 9
Jti
��9 <
,
��< =
Guid
��> B
.
��B C
NewGuid
��C J
(
��J K
)
��K L
.
��L M
ToString
��M U
(
��U V
)
��V W
)
��W X
)
��X Y
;
��Y Z
claims
�� 
.
�� 
Add
�� 
(
�� 
new
�� 
Claim
��  
(
��  !%
JwtRegisteredClaimNames
��! 8
.
��8 9
Nbf
��9 <
,
��< =
DateTime
��> F
.
��F G
Now
��G J
.
��J K
ToString
��K S
(
��S T
)
��T U
)
��U V
)
��V W
;
��W X
claims
�� 
.
�� 
Add
�� 
(
�� 
new
�� 
Claim
��  
(
��  !%
JwtRegisteredClaimNames
��! 8
.
��8 9
Iat
��9 <
,
��< =
DateTime
��> F
.
��F G
Now
��G J
.
��J K
ToString
��K S
(
��S T
)
��T U
)
��U V
)
��V W
;
��W X
if
�� 
(
�� 
isAccessToken
�� 
)
�� 
{
�� 
var
�� 

userClaims
�� 
=
��  
await
��! &
UserManager
��' 2
.
��2 3
GetClaimsAsync
��3 A
(
��A B
user
��B F
)
��F G
;
��G H
var
�� 
roles
�� 
=
�� 
await
�� !
UserManager
��" -
.
��- .
GetRolesAsync
��. ;
(
��; <
user
��< @
)
��@ A
;
��A B
claims
�� 
.
�� 
AddRange
�� 
(
��  

userClaims
��  *
)
��* +
;
��+ ,
foreach
�� 
(
�� 
var
�� 
role
��  
in
��! #
roles
��$ )
)
��) *
{
�� 
claims
�� 
.
�� 
Add
�� 
(
�� 
new
�� "
Claim
��# (
(
��( )
$str
��) /
,
��/ 0
role
��1 5
)
��5 6
)
��6 7
;
��7 8
}
�� 
}
�� 
return
�� 
claims
�� 
;
�� 
}
�� 	
public
�� 
async
�� 
Task
�� 
<
�� 
	ECommUser
�� #
>
��# $

GetByEmail
��% /
(
��/ 0
string
��0 6
email
��7 <
)
��< =
{
�� 	
var
�� 
user
�� 
=
�� 
await
�� 
UserManager
�� (
.
��( )
FindByEmailAsync
��) 9
(
��9 :
email
��: ?
)
��? @
;
��@ A
return
�� 
user
�� 
;
�� 
}
�� 	
public
�� 
async
�� 
Task
�� 
<
�� 
List
�� 
<
�� 
	ECommUser
�� (
>
��( )
>
��) * 
GetNonDefaultUsers
��+ =
(
��= >
)
��> ?
{
�� 	
var
�� 
users
�� 
=
�� 
new
�� 
List
��  
<
��  !
	ECommUser
��! *
>
��* +
(
��+ ,
)
��, -
;
��- .
var
�� 
usersFromDb
�� 
=
�� 
_unitOfWork
�� )
.
��) *
	UserRoles
��* 3
.
��3 4
GetAll
��4 :
(
��: ;
)
��; <
;
��< =
foreach
�� 
(
�� 
var
�� 

userFromDb
�� #
in
��$ &
usersFromDb
��' 2
)
��2 3
{
�� 
var
�� 
user
�� 
=
�� 
await
��  
UserManager
��! ,
.
��, -
FindByIdAsync
��- :
(
��: ;

userFromDb
��; E
.
��E F
UserId
��F L
)
��L M
;
��M N
if
�� 
(
�� 
user
�� 
!=
�� 
null
�� 
)
��  
users
��! &
.
��& '
Add
��' *
(
��* +
user
��+ /
)
��/ 0
;
��0 1
}
�� 
return
�� 
users
�� 
;
�� 
}
�� 	
}
�� 
}�� �
cC:\Dev\Projects\.NET Work\E-CommerceApp\E-Commerce.Services\Services\Implementations\RoleService.cs
	namespace		 	

E_Commerce		
 
.		 
Services		 
.		 
Services		 &
.		& '
Implementations		' 6
{

 
public 

class 
RoleService 
{ 
private 
UserManager 
< 
	ECommUser %
>% &
_userManager' 3
{4 5
get6 9
;9 :
}; <
private 
RoleManager 
< 
IdentityRole (
>( )
_roleManager* 6
{7 8
get9 <
;< =
}> ?
private 
IUnitOfWork 
_unitOfWork '
{( )
get* -
;- .
}/ 0
public 
RoleService 
( 
UserManager &
<& '
	ECommUser' 0
>0 1
userManager2 =
,= >
RoleManager? J
<J K
IdentityRoleK W
>W X
roleManagerY d
,d e
IUnitOfWorkf q

unitOfWorkr |
)| }
{ 	
_userManager 
= 
userManager &
;& '
_roleManager 
= 
roleManager &
;& '
} 	
public 
async 
void 
AddAdmin "
(" #
	ECommUser# ,
user- 1
)1 2
{ 	
} 	
public 
async 
Task 
< 
bool 
> 
AddRole  '
(' (
string( .
roleName/ 7
,7 8
List9 =
<= >
Claim> C
>C D
claimsE K
)K L
{ 	
var   
role   
=   
new   
IdentityRole   '
(  ' (
roleName  ( 0
)  0 1
;  1 2
var!! 
result!! 
=!! 
await!! 
_roleManager!! +
.!!+ ,
CreateAsync!!, 7
(!!7 8
role!!8 <
)!!< =
;!!= >
if"" 
("" 
!"" 
result"" 
."" 
	Succeeded""  
)""  !
{## 
return$$ 
false$$ 
;$$ 
}%% 
return&& 
true&& 
;&& 
}(( 	
public** 
void** 
AssignClaimToRole** %
(**% &
IdentityRole**& 2
role**3 7
,**7 8
Claim**9 >
claim**? D
)**D E
{++ 	
}.. 	
public// 
List// 
<// 
IdentityRole//  
>//  !
?//! "
GetRoles//# +
(//+ ,
)//, -
{00 	
var11 
roles11 
=11 
_roleManager11 $
.11$ %
Roles11% *
.11* +
ToList11+ 1
(111 2
)112 3
;113 4
if22 
(22 
!22 
roles22 
.22 
IsNullOrEmpty22 $
(22$ %
)22% &
)22& '
return22( .
roles22/ 4
;224 5
return44 
new44 
List44 
<44 
IdentityRole44 (
>44( )
(44) *
)44* +
;44+ ,
}55 	
}66 
}77 �

cC:\Dev\Projects\.NET Work\E-CommerceApp\E-Commerce.Services\Services\Interfaces\IIdentityService.cs
	namespace		 	

E_Commerce		
 
.		 
Services		 
.		 
Services		 &
.		& '

Interfaces		' 1
{

 
public 

	interface 
IIdentityService %
{ 
Task 
< 
RegisterResponse 
> 
RegisterUser +
(+ ,
RegisterRequest, ;
request< C
)C D
;D E
Task 
< 
LoginResponse 
> 
	LoginUser %
(% &
LoginRequest& 2
request3 :
): ;
;; <
Task 
< 
LoginResponse 
>  
LoginWithoutPassword 0
(0 1
string1 7
	userEmail8 A
)A B
;B C
Task 
< 
	ECommUser 
> 

GetByEmail "
(" #
string# )
email* /
)/ 0
;0 1
Task 
< 
List 
< 
	ECommUser 
> 
> 
GetNonDefaultUsers 0
(0 1
)1 2
;2 3
} 
} 