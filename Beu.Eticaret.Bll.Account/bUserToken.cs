using Beu.Eticaret.Account.UserToken;
using Beu.Eticaret.Dal.Account;
using Beu.Eticaret.Db.Account.DataAccess;
using Beu.Eticaret.Entity;
using Beu.Eticaret.Entity.Account;
using Beu.Eticaret.Web.Auth;
using Microsoft.Extensions.Configuration;
using System;

namespace Beu.Eticaret.Bll.Account
{
    public class bUserToken
    {
        private readonly TokenService _tokenService;
        private readonly TokenOptions _tokenOptions;
        public bUserToken(IConfiguration configuration)
        {
            _tokenOptions = configuration.GetSection(TokenOptions.TokenOption).Get<TokenOptions>();
            _tokenService = new TokenService(_tokenOptions);
        }

        public rUserToken Get(pbUserToken args)
        {
            using (DbEntities db = new DbEntities())
            {
                var userTokenD = new dUserToken(db);

                try
                {
                    return userTokenD.Get(args);
                }
                catch (SystemException)
                {
                    return new rUserToken() { Error = true, Message = "Error" };
                }
            }
        }

        public rToken RevokeRefreshToken(pbUserToken args)
        {
            using (DbEntities db = new DbEntities())
            {
                try
                {
                    var userRefreshD = new dUserToken(db);
                    var existRefreshToken = userRefreshD.Get(new pbUserToken { RefreshToken = args.RefreshToken });

                    if (existRefreshToken == null)
                    {
                        return new rToken
                        {
                            Value = null,
                            Error = true,
                        };
                    }

                    userRefreshD.Delete(new pId { Id = existRefreshToken.Value.Id });

                    var token = _tokenService.RevokeAccessToken();
                    return new rToken
                    {
                        Value = new eToken
                        {
                            AccessToken = token.AccessToken,
                            AccessTokenExpiration = token.AccessTokenExpiration
                        },
                        Error = false,
                    };

                }
                catch (SystemException)
                {
                    return new rToken() { Error = true, Message = "Error" };
                }
            }
        }

        public rToken CreateTokenByRefreshToken(pbUserToken args)
        {
            using (DbEntities db = new DbEntities())
            {
                try
                {
                    var userRefreshD = new dUserToken(db);

                    var existRefreshToken = userRefreshD.Get(new pbUserToken { RefreshToken = args.RefreshToken });

                    if (existRefreshToken.Value == null)
                    {
                        return new rToken() { Error = true, Message = "Error" };
                    }

                    var userD = new dUser(db);

                    var userValue = userD.Get(new pUser { Id = (int)existRefreshToken.Value.UserId });

                    if (userValue.Value == null)
                    {
                        return new rToken() { Error = true, Message = "Error" };
                    }

                    var user = userValue.Value;

                    var token = _tokenService.CreateToken(
                       new pToken
                       {
                           Id = user.Id,
                           Name = user.Name,
                           Surname = user.Surname,
                           Email=user.Email,
                           Password = user.Password,
                       });

                    var refreshToken = userRefreshD.Update(
                        new pUserToken
                        {
                            Id = existRefreshToken.Value.Id,
                            UserId = userValue.Value.Id,
                            RefreshToken = token.RefreshToken,
                            RefreshTokenExpireDate = token.RefreshTokenExpiration
                        });

                    return new rToken
                    {
                        Value = new eToken
                        {
                            Name = user.Name,
                            AccessToken = token.AccessToken,
                            AccessTokenExpiration = token.AccessTokenExpiration,
                            RefreshToken = token.RefreshToken,
                            RefreshTokenExpiration = token.RefreshTokenExpiration
                        }
                    };

                }
                catch (SystemException)
                {
                    return new rToken() { Error = true, Message = "Error" };
                }
            }
        }

        public rToken Login(pUser args)
        {
            using (DbEntities db = new DbEntities())
            {
                try
                {
                    var userD = new dUser(db);
                    var userValue = userD.Get(args);
                    if (userValue == null)
                    {
                        return new rToken() { Error = true, Message = "Error" };
                    }

                    var user = userValue.Value;

                    var token = _tokenService.CreateToken(
                        new pToken
                        {
                            Id = user.Id,
                            Name = user.Name,
                            Surname = user.Surname,
                            Email = user.Email,
                            Password = user.Password,                           
                            AccessLevel = user.AccessLevel,
                        });

                    var userRefreshD = new dUserToken(db);

                    var userRefreshToken = userRefreshD.Get(new pbUserToken { UserId = user.Id });

                    if (userRefreshToken.Value == null)
                    {
                        var addedRefreshToken = userRefreshD.Add(
                            new pUserToken
                            {
                                UserId = user.Id,
                                RefreshToken = token.RefreshToken,
                                RefreshTokenExpireDate = token.RefreshTokenExpiration
                            });

                        return new rToken
                        {
                            Value = new eToken
                            {
                                Id = user.Id,
                                AccessLevel = user.AccessLevel,
                                AccessToken = token.AccessToken,
                                AccessTokenExpiration = token.AccessTokenExpiration,
                                RefreshToken = token.RefreshToken,
                                RefreshTokenExpiration = token.RefreshTokenExpiration
                            }
                        };
                    }
                    else
                    {
                        var updatedRefreshToken = userRefreshD.Update(
                            new pUserToken
                            {
                                Id = userRefreshToken.Value.Id,
                                UserId = userRefreshToken.Value.UserId,
                                RefreshToken = token.RefreshToken,
                                RefreshTokenExpireDate = token.RefreshTokenExpiration
                            });

                        var rToken = updatedRefreshToken.Value;
                        return new rToken
                        {
                            Value = new eToken
                            {
                                Id = user.Id,
                                AccessLevel = user.AccessLevel,
                                AccessToken = token.AccessToken,
                                AccessTokenExpiration = token.AccessTokenExpiration,
                                RefreshToken = token.RefreshToken,
                                RefreshTokenExpiration = token.RefreshTokenExpiration
                            }
                        };
                    }
                }
                catch (SystemException)
                {
                    return new rToken() { Error = true, Message = "Error" };
                }
            }
        }

        public rUserToken Add(pUserToken args)
        {
            using (DbEntities db = new DbEntities())
            {
                var userTokenD = new dUserToken(db);

                try
                {
                    return userTokenD.Add(args);
                }
                catch (SystemException)
                {
                    return new rUserToken() { Error = true, Message = "Error" };
                }
            }
        }

        public rUserToken Update(pUserToken args)
        {
            using (DbEntities db = new DbEntities())
            {
                var userTokenD = new dUserToken(db);

                try
                {
                    return userTokenD.Update(args);
                }
                catch (SystemException)
                {
                    return new rUserToken() { Error = true, Message = "Error" };
                }
            }
        }

        public rUserToken Save(pUserToken args)
        {
            using (DbEntities db = new DbEntities())
            {
                var userTokenD = new dUserToken(db);

                try
                {
                    return userTokenD.Save(args);
                }
                catch (SystemException)
                {
                    return new rUserToken() { Error = true, Message = "Error" };
                }
            }
        }

        public rCore Delete(pId args)
        {
            using (DbEntities db = new DbEntities())
            {
                var userTokenD = new dUserToken(db);

                try
                {
                    return userTokenD.Delete(args);
                }
                catch (SystemException)
                {
                    return null;
                }
            }
        }
    }
}
