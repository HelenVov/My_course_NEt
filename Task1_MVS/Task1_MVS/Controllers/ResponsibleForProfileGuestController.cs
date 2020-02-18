using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task1_MVS.Models;
using Task1_MVS.Models.ViewModels;

namespace Task1_MVS.Controllers
{
    public class ResponsibleForProfileGuestController:Controller
    {
        [AcceptVerbs("GET", "POST")]
        public ActionResult ProfileGuest(GuestProfileViewModel data = null)
        {
            if (Request.HttpMethod == "POST")
            {
                if (ModelState.IsValid)
                {
                    var randomResult = GetRandomResult(data);
                    var profileQuestions = GetQuestionViewModel().Questions;
                    randomResult.GuestProfile.Questions = profileQuestions;
                    return View("ResultProfile", randomResult);
                }
            }
            var profile = CreateProfile();
            return View(profile);
        }

        private GuestProfileViewModel CreateProfile()
        {
            var questions = GetQuestionViewModel().Questions;

            var guestProfile = new GuestProfileViewModel
            {
                Questions = questions,
                Answers = new int[questions.Count]
            };

            return guestProfile;
        }

        private ResultFairyViewModel GetRandomResult(GuestProfileViewModel data)
        {
            var nameFairies = new List<string>
            {
                "Блум",
                "Стелла",
                "Флора",
                "Муза",
                "Текна",
                "Лейла"
            };
            var random = new Random();
            var number = random.Next(0, 6);
            var fairy = new ResultFairyViewModel
            {
                Name = nameFairies[number],
                ImgSrc = "/Content/img/" + number + ".png",
                GuestProfile = data
            };
            return fairy;
        }


        private QuestionsViewModel GetQuestionViewModel()
        {
            return new QuestionsViewModel
            {
                Questions = new List<QuestionViewModel>()
                {
                    new QuestionViewModel
                    {
                        Name = "Question1",
                        QuestionText = "1. Вас позвали на потрясающую вечеринку, которая будет сегодня вечером.",
                        Options = new List<string>
                        {
                            "Здорово! Очень буду рада прийти.",
                            "Так поздно позвали! Я же не успею подготовиться. Срочно в магазин!",
                            "А кто-то из моих знакомых пойдет? Одна не хочу!",
                            "Даже не знаю… может не идти?"
                        },
                    },
                    new QuestionViewModel
                    {
                        Name = "Question2",
                        QuestionText =
                            "2. Вы ждете подругу в торговом центре, и у вас есть еще много времени до ее прихода. Вы…",
                        Options = new List<string>
                        {
                            "Покопаюсь в телефоне, посижу в Интернете.",
                            "Схожу в кино или еще куда-нибудь поблизости.",
                            "Поеду ей навстречу, чтобы не скучать.",
                            "Прошвырнусь по магазинам или зайду в кафе."
                        }
                    },
                    new QuestionViewModel
                    {
                        Name = "Question3",
                        QuestionText = "3. На день рождения вы хотели бы получить в подарок…",
                        Options = new List<string>
                        {
                            "Хорошую книгу.",
                            "Сертификат на какие-нибудь курсы.",
                            "Новый айфон.",
                            "Что-нибудь милое и запоминающееся."
                        }
                    },
                    new QuestionViewModel
                    {
                        Name = "Question4",
                        QuestionText = "4. Ваши друзья в беде. В первую очередь надо…",
                        Options = new List<string>
                        {
                            "Побежать им на помощь!",
                            "Позвать на помощь кого-нибудь еще.",
                            "Проанализировать ситуацию.",
                            "Не угодить в беду самой!"
                        }
                    },
                    new QuestionViewModel
                    {
                        Name = "Question5",
                        QuestionText = "5. Про вас распространяют неприятные слухи. Вы…",
                        Options = new List<string>
                        {
                            "Не обращаю на это внимания.",
                            "Меня это сильно заденет, но я промолчу.",
                            "Найду того, кто это делает и поговорю с ним.",
                            "Начну распространять слухи про обидчика в ответ."
                        }
                    },
                    new QuestionViewModel
                    {
                        Name = "Question6",
                        QuestionText = "6. Переключая каналы на телевизоре, скорее всего вы остановитесь на…",
                        Options = new List<string>
                        {
                            "Передаче про природу и путешествия.",
                            "Концерте любимой группы.",
                            "Новостях или научной передаче.",
                            "Каком-нибудь сериальчике или фильме."
                        }
                    }

                }
            };
        }
    }
}