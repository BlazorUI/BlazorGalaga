﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using Blazor.Extensions.Canvas.Canvas2D;
using BlazorGalaga.Models;
using BlazorGalaga.Static;
using System.Linq;

namespace BlazorGalaga.Services
{
    public class AnimationService
    {
        public List<Animation> Animations = new List<Animation>();
        public Canvas2DContext CanvasCtx { get; set; }

        private BezierCurveService bezierCurveService;
        private SpriteService spriteService;

        public AnimationService(BezierCurveService bcs, SpriteService ss)
        {
            bezierCurveService = bcs;
            spriteService = ss;
        }

        public void InitAnimations()
        {
            Animations.AddRange(BugFactory.CreateAnimation_BugIntro1());

            //var shipAnimation = new Animation() { Speed = 0 };
            //List<BezierCurve> paths2 = new List<BezierCurve>();
            //paths2.Add(new BezierCurve()
            //{
            //    StartPoint = new PointF(0, Constants.CanvasSize.Height - Constants.SpriteDestSize.Height),
            //    EndPoint = new PointF(Constants.CanvasSize.Width - Constants.SpriteDestSize.Width, Constants.CanvasSize.Height - Constants.SpriteDestSize.Height),
            //    ControlPoint1 = new PointF(0, Constants.CanvasSize.Height - Constants.SpriteDestSize.Height),
            //    ControlPoint2 = new PointF(0, Constants.CanvasSize.Height - Constants.SpriteDestSize.Height)
            //});
            //var ship = new Ship()
            //{
            //    Paths = paths2,
            //    DrawPath = false,
            //    PathIsLine = true,
            //    RotateAlongPath = false
            //};
            //shipAnimation.Animatables.Add(ship);
            //Animations.Add(shipAnimation);

        }

        public async Task ResetCanvas()
        {
            await CanvasCtx.ClearRectAsync(0, 0, Constants.CanvasSize.Width, Constants.CanvasSize.Height);
            await CanvasCtx.SetFillStyleAsync("#000000");
            await CanvasCtx.FillRectAsync(0, 0, Constants.CanvasSize.Width, Constants.CanvasSize.Height);
        }

        public void Animate(Animation animation)
        {
            if (animation.StartDelay > 0)
            {
                animation.StartDelay -= animation.Speed;
                return;
            }

            animation.Percent += animation.Speed;

            if (animation.Percent < 0)
            {
                animation.Percent = 0;
                if (animation.LoopBack) animation.Speed *= -1;
            }
            else if (animation.Percent > 100)
            {
                animation.Percent = 100;
                if (animation.LoopBack) animation.Speed *= -1;
            };

        }

        public void ComputePathPoints()
        {
            foreach (var animation in Animations) {
                foreach (var animatable in animation.Animatables)
                {
                    if (animatable.Paths != null)
                    {
                        foreach (BezierCurve path in animatable.Paths.OrderBy(a => a.StartPercent))
                        {
                            bezierCurveService.DrawCurve(CanvasCtx, path);
                            for (var percent = 0F; percent <= 100; percent+=.1F)
                            {
                                var point = bezierCurveService.getCubicBezierXYatPercent(path, percent);
                                animation.PathPoints.Add(point);
                            }
                        }
                    }
                }
                animation.PathPoints = bezierCurveService.GetEvenlyDistributedPathPointsByLength(animation.PathPoints, 10);
                foreach (var p in animation.PathPoints)
                {
                    CanvasCtx.BeginPathAsync();
                    CanvasCtx.SetFillStyleAsync("yellow");
                    CanvasCtx.ArcAsync(p.X, p.Y, 3, 0, Math.PI * 2);
                    CanvasCtx.FillAsync();
                    CanvasCtx.ClosePathAsync();
                }
            }
        }

        public void Draw(Animation animation)
        {
            //http://jsfiddle.net/m1erickson/LumMX/

            foreach (var animatable in animation.Animatables)
            {
                if (animatable.Paths != null)
                {
                    foreach (BezierCurve path in animatable.Paths.OrderBy(a => a.StartPercent))
                    {
                        if (animation.Percent >= path.StartPercent && (animation.Percent < (path.StartPercent + path.PercentageOfPath)))
                        {
                            var animationpercent = ((animation.Percent - path.StartPercent) / path.PercentageOfPath) * 100;

                            if (animatable.PathIsLine)
                            {
                                animatable.PevLocation = bezierCurveService.getLineXYatPercent(path, animationpercent - animation.Speed);
                                animatable.Location = bezierCurveService.getLineXYatPercent(path, animationpercent);
                                animatable.NextLocation = bezierCurveService.getLineXYatPercent(path, animationpercent + animation.Speed);
                            }
                            else
                            {
                                animatable.PevLocation = bezierCurveService.getCubicBezierXYatPercent(path, animationpercent - animation.Speed);
                                animatable.Location = bezierCurveService.getCubicBezierXYatPercent(path, animationpercent);
                                animatable.NextLocation = bezierCurveService.getCubicBezierXYatPercent(path, animationpercent + animation.Speed);
                            }
                        }
                        if (animatable.DrawPath) bezierCurveService.DrawCurve(CanvasCtx, path);
                    }
                }

                if (animatable.Sprite != null)
                {
                    var rotation = bezierCurveService.GetRotationAngleAlongPath(animatable);
                    spriteService.DrawSprite(animatable.Sprite, animatable.Location, animatable.RotateAlongPath ? rotation : 0);
                }
            }
        }
    }
}