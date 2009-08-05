//  This file is part of NHibernate.ReLinq.Sample a sample showing
//  the use of the open source re-linq library to implement a non-trivial 
//  Linq-provider, on the example of NHibernate (www.nhibernate.org).
//  Copyright (C) 2005-2009 rubicon informationstechnologie gmbh, www.rubicon.eu
//  
//  NHibernate.ReLinq.Sample is based on re-motion re-linq (http://www.re-motion.org/).
//  
//  NHibernate.ReLinq.Sample is free software; you can redistribute it 
//  and/or modify it under the terms of the GNU Lesser General Public License 
//  version 3.0 as published by the Free Software Foundation.
//  
//  re-motion is distributed in the hope that it will be useful, 
//  but WITHOUT ANY WARRANTY; without even the implied warranty of 
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the 
//  GNU Lesser General Public License for more details.
//  
//  You should have received a copy of the GNU Lesser General Public License
//  along with NHibernate.ReLinq.Sample; if not, see http://www.gnu.org/licenses.
// 
namespace NHibernate.ReLinq.Sample.HqlQueryGeneration
{
  public class CommandData
  {
    public CommandData (string statement, NamedParameter[] namedParameters)
    {
      Statement = statement;
      NamedParameters = namedParameters;
    }

    public string Statement { get; private set; }
    public NamedParameter[] NamedParameters { get; private set; }

    public IQuery CreateQuery (ISession session)
    {
      var query = session.CreateQuery (Statement);

      foreach (var parameter in NamedParameters)
        query.SetParameter (parameter.Name, parameter.Value);

      return query;
    }
  }
}